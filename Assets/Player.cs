using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {



	public float cameraSensitivity = 90;
	public float normalMoveSpeed = 10;
	public float slowMoveFactor = 0.25f;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

	void Start ()
	{
		Screen.lockCursor = true;
	}

	void Update ()
	{
		rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, -90, 90);

		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

		if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))
		{
			transform.position += new Vector3(transform.forward.x * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime, 0, transform.forward.z * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime);
			transform.position += new Vector3(transform.right.x * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime, 0, transform.right.z * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime);
		}
		else
		{
			transform.position += new Vector3(transform.forward.x * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0, transform.forward.z * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
			transform.position += new Vector3(transform.right.x * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, transform.right.z * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.End))
		{
			Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
		}
	}
}