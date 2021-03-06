using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
	public float revertTimer = 1.0f;
	private float tmp = 0f;
	private bool hasFallen = false; //Whether or not a player has jumped
	private PlatformEffector2D effector; //reference to the platform effector on all platforms

	void Start()
	{
		//Grab the refence to the platform effector and set the waiting time to the determined wait timer
		effector = GetComponent<PlatformEffector2D>();
		tmp = revertTimer;
	}

	void FixedUpdate()
	{
		//If the player presses a key to get down from the platform...
		if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
		{
			effector.rotationalOffset = 180f;
			hasFallen = true;
		}

		//If the player has fallen...
		if (hasFallen)
		{
			revertTimer -= Time.fixedDeltaTime; //Start decreasing the timer
		}

		//Caso o tempo chegue a zero...
		if(revertTimer <= 0)
        {
			hasFallen = false;//Report that the player hasn't fallen
			revertTimer = tmp; //Reset timer
			effector.rotationalOffset = 0.0f; //Revert the rotational offset timer
        }
	}
}
