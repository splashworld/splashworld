using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Vector3 movementVector;

	private CharacterController characterController;

	private float movementSpeed = 8;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		movementVector.x = Input.GetAxis("LeftJoystickX_P") * movementSpeed;

		movementVector.z = Input.GetAxis("LeftJoystickY_P") * movementSpeed;

		movementVector.y = 0;

		characterController.Move(movementVector * Time.deltaTime);
	}
}
