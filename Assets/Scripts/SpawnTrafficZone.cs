using UnityEngine;
using System.Collections;

/* TO DO:
 * 
 * Want to vary spawn zone density and how fast the cars move and their variance from that average speed so some streets will be easier or harder to travel on.
 * 
 * Each car casts a ray on its forward vector to see if it's about to collide with something then comes to a stop then starts again when clear. May have to do some 
 * fancier calculations to make it more realistic.
 * 
 */


/// <summary>
/// This script will spawn car prefabs anywhere inside the renderable mesh ("zone") and set their velocities randomly in the direction of the forward vector of the zone.
/// </summary>
public class SpawnTrafficZone : MonoBehaviour {

	// The prefab of the car to spawn.
	public GameObject carPrefab = null;

	// How long until we should spawn the next car
	float nextCarTimer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		// Disable collider if there is one on this object so rigid bodies will spawn properly inside
		if (GetComponent<Collider> () != null) 
		{
			GetComponent<Collider>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		nextCarTimer -= Time.deltaTime;

		// If timer has run out to create a new car
		if (nextCarTimer <= 0.0f) 
		{
			if (carPrefab != null)
			{
				// get the bounding box of the area we can spawn cars inside
				Bounds areaBounds = this.GetComponent<Renderer>().bounds;
				Vector3 newCarPosition = new Vector3(Random.Range(areaBounds.min.x, areaBounds.max.x),
				                                     Random.Range(areaBounds.min.y, areaBounds.max.y),
				                                     Random.Range(areaBounds.min.z, areaBounds.max.z));
				
				// determine the speed of the new car
				float newCarVelocity = Random.Range(10, 15);
				
				// TO DO: also make sure the newly instantiated car doesn't overlap any recently instantiated ones
				
				GameObject newCar = (GameObject)Instantiate(carPrefab);
				newCar.transform.position = newCarPosition;
				newCar.GetComponent<SimpleFlyingCar>().TopVelocity = newCarVelocity;
			}
			
			nextCarTimer = 0.175f; //Random.Range(0.5f, 1.0f);
		}
	}
}
