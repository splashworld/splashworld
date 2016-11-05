using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{


	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{

		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }
	}
}
