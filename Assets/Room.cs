using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {
	int min = -50;
	int max =50;
	const float totalTime = 3f;
	float timeLeft;
	GUIStyle style;
	GUIStyle style2;
	public int score;

	private bool go;


	public GameObject target1;
	public GameObject tree;

	void Start () {
		Time.timeScale = 1;
		timeLeft = totalTime;

		style = new GUIStyle();
		style.fontSize=30;
		score = 0;
		go = false;

		style2 = new GUIStyle ();
		style2.fontSize = 100;

		initTargets ();
		initTrees ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space))
		{
			go = true;
		}
		if (timeLeft > 0 && go) {
			timeLeft -= Time.deltaTime;
		} 
		else if(timeLeft <= 0){
			Time.timeScale=0;
		}
	}
		

	void OnGUI(){
		
		GUI.color = Color.white;
		GUI.Label (new Rect (40, 5, 200, 200), "Time: "+timeLeft.ToString ("F0"), style);
		GUI.Label (new Rect (Screen.width - 150, 5, 200, 200), "Score: "+score.ToString(), style); 
		GUI.Label(new Rect(Screen.width/2-5, Screen.height/2-5,10,10), "+",style);

		if (timeLeft == totalTime) {
			GUI.Label (new Rect (50, Screen.height / 2 - 50, 10, 10), "Shoot apples and floating cubes. Beware of trees.", style2);
		}

		if (timeLeft <= 0) {
			GUI.Label (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 50, 10, 10), "Game Over!", style2);
			GUI.Label (new Rect (Screen.width / 2 - 400, Screen.height / 2+50, 10, 10), "Press Return to restart", style2);
			GUI.Label (new Rect (Screen.width / 2 - 400, Screen.height / 2+50, 10, 10), "Press Escape to quit", style2);
			if (Input.GetKeyUp(KeyCode.Return)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			if (Input.GetKeyUp(KeyCode.Escape)) {
				Application.Quit ();
			}
		}
			
	}

	void initTargets()
	{
		for (int i = 0; i < 30; i++) {
			float x = Random.Range (min, max);
			float z = Random.Range (min, max);
			float y = Random.Range (1f, max/2);
			Instantiate(target1);
			target1.transform.position = new Vector3 (x, y, z);
			target1.gameObject.GetComponent<TargetBehavior> ().r = this;
		}
	}

	void initTrees()
	{
		for (int i = 0; i < 10; i++) {
			float x = Random.Range (min, max);
			float z = Random.Range (min, max);

			Instantiate(tree);
			tree.transform.position = new Vector3 (x, 0, z);
			tree.gameObject.GetComponent<Tree> ().r = this;
			tree.gameObject.GetComponent<Tree> ().init ();
		}
	}
}
