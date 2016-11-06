using UnityEngine;
using System.Collections;

public class paintballGun : MonoBehaviour {

    public GameObject paintball;
    public GameObject gunModel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
			Instantiate (paintball, transform.position, transform.rotation);
        }

	}
}
