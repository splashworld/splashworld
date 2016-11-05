using UnityEngine;
using System.Collections;

public class Paintball : MonoBehaviour {

    public Rigidbody rigidbody;
    public int speed;

	// Use this for initialization
	void Start () {
        rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
