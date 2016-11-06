using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
	int min = -20;
	int max =20;
	float timeLeft=30f;
	GUIStyle style;
	public int score;


	public GameObject target1;

	void Start () {
		style = new GUIStyle();
		style.fontSize=20;
		score = 0;


		for (int i = 0; i < 30; i++) {
			float x = Random.Range (min, max);
			float z = Random.Range (min, max);
			float y = Random.Range (1f, max/2);
			Instantiate(target1);
			target1.transform.position = new Vector3 (x, y, z);
			target1.gameObject.GetComponent<TargetBehavior> ().r = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
		} else {
			Time.timeScale=0;
		}
	}

	void OnGUI(){
		GUI.color = Color.white;
		GUI.Label (new Rect (5, 5, 200, 200), timeLeft.ToString ("F0"), style);
		GUI.Label (new Rect (Screen.width - 200, 5, 200, 200), score.ToString(), style); 
		GUI.Label(new Rect(Screen.width/2-5, Screen.height/2-5,10,10), "+",style);
	}
}
