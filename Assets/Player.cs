using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Rigidbody rigidbody;
	public float speed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool getLeft = Input.GetKey (KeyCode.A);
		bool getRight = Input.GetKey (KeyCode.D);
		bool getFoward = Input.GetKey (KeyCode.W);
		bool getBack = Input.GetKey (KeyCode.S);

		Vector3 currentPosition = transform.position;

		if(getLeft) {
			currentPosition.x -= speed * Time.deltaTime;
		}
		else if(getRight){
			currentPosition.x += speed * Time.deltaTime;
	}
		if (getFoward) {
			currentPosition.z += speed * Time.deltaTime;
		}
		else if (getBack) {
			currentPosition.z -= speed * Time.deltaTime;
		}

		transform.position =currentPosition;
}
}