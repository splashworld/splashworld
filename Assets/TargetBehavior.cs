using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{
	public bool isHit;
	public Room r;
	public Paintball p;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{

		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {
			gameObject.GetComponent<Renderer>().material.color = newCollision.gameObject.GetComponent<Renderer>().material.color;
			if (!isHit) {
				r.score++;
				isHit = true;
			}
        }
	}
}
