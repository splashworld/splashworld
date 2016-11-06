using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	GUIStyle style;
	public GameObject button;
	void Start () {
		style = new GUIStyle();
		style.fontSize=30;
		Instantiate(button);
		button.transform.position = new Vector3 (0f, 6.13f, -10f);
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.color = Color.white;
		GUI.Label (new Rect (10,10, 200, 200), "START", style);

	}
}
