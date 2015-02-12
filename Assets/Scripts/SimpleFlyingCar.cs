using UnityEngine;
using System.Collections;

// Component requirements
[RequireComponent (typeof (Rigidbody))]

/// <summary>
/// A Simple version of a flying car that will drive for a certain distance and then respawn at its starting point,
/// looping over and over again.
/// </summary>
public class SimpleFlyingCar : MonoBehaviour 
{
	public float TopVelocity = 20.0f;
	
	// NOTE: Plans for future scripts
	//	- Just use Unity's built in pathfinding?
	//	- Stop at intersection, maybe turn.
	
	private Vector3 startingPos;
	
	// Use this for initialization
	void Start () 
	{
		// Store the starting position so we can relocate here after the car has reached a certain point.
		startingPos = transform.position; //rigidbody.position;
		
		// Set the linear velocity on the forward vector (dynamic only)
		//rigidbody.velocity = rigidbody.transform.forward * TopVelocity;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// use this if kinematic rigid body
		rigidbody.transform.Translate (rigidbody.transform.forward * TopVelocity * Time.deltaTime);
		
		// Check if the distance from the starting point has exceeded a certain amount
		if (Vector3.Distance (startingPos, rigidbody.transform.position) > 100.0f) 
		{
			Destroy(this.gameObject); // note: this is the proper way to destroy an object
			
			//rigidbody.MovePosition(startingPos);
			
			// Reposition to starting position. NOTE: just setting it to startingPos doesn't work
			// because Unity is for children
			//transform.position = new Vector3(startingPos.x, startingPos.y, startingPos.z);
		}
	}
}
