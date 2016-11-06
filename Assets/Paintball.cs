using UnityEngine;
using System.Collections;

public class Paintball : MonoBehaviour
{

    public Rigidbody rigidbody;
    public int speed;
	public paintballGun pg;
	public Color newColor;
    // Use this for initialization
    void Start()
    {
		newColor = new Color (Random.value, Random.value, Random.value, 1.0f);
		gameObject.GetComponent<Renderer>().material.color = newColor;
        rigidbody.velocity = transform.forward * speed;

    }
    void OnCollisionEnter(Collision newCollision)
    {

		gameObject.GetComponent<Renderer>().material.color = newColor;
        Destroy(gameObject);
    }




    }