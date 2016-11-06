using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour {
	GUIStyle style;
	public MainMenu m;
	public Paintball p;
	void Start () {
		
	}
		
void OnCollisionEnter (Collision newCollision)
{
	if (newCollision.gameObject.tag == "Projectile") {
		Application.LoadLevel(1);
	}


	
}
}
