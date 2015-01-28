using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterMotor))]
public class ParentWhenLanded : MonoBehaviour 
{
	// NOTE: use downward raycasting if there isn't already an isGrounded somewhere in character controller

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("OnCollisionEnter! " + col.contacts [0].otherCollider.gameObject.name);

		// NOTE: temporary; parent this transform's parent to whatever the character landed on so he'll move with it.
		// Need to also do a validity check later.
		this.transform.parent = col.contacts [0].otherCollider.gameObject.transform;
	}
	
	/*void OnTriggerEnter(Collider collider)
	{
		Debug.Log ("OnTriggerEnter");

		// TO DO: put in checks for tags of object landed on (car, platform, etc.) AND do checks if we are landing
		// on top of the object instead of on the side. Maybe cast a ray straight down and see if it collides with
		// the same object?

		// parent this to the object landed on
		Debug.Log ("Name: " + collider.gameObject.name);
	}*/
	
	void OnControllerColliderHit(ControllerColliderHit hit) 
	{
		/*if (this.GetComponent<CharacterMotor> ().jumping.jumping) 
		{
			this.transform.parent = null;
		}*/
		
		//Debug.Log ("Landed!");
		
		/*Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;*/
		
	}
}
