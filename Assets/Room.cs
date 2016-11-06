using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {
	int min = -50;
	int max =50;
	const float totalTime = 60f;
	float timeLeft;
	GUIStyle style;
	GUIStyle style2;
	GUIStyle style3;
	GUIStyle style4;
	public int score;

	private bool go;
	int highscore;

	public GameObject target1;
	public GameObject tree;


	void Start () {
		highscore = PlayerPrefs.GetInt("High Score");

		Time.timeScale = 1;
		timeLeft = totalTime;

		style = new GUIStyle();
		style.fontSize = 30;
		score = 0;
		go = false;

		style2 = new GUIStyle ();
		style2.fontSize = 80;
		style2.alignment = TextAnchor.UpperCenter;

		style3 = new GUIStyle();
		style3.fontSize = 30;
		style3.alignment = TextAnchor.UpperCenter;

		style4 = new GUIStyle();
		style4.fontSize = 160;
		style4.alignment = TextAnchor.UpperCenter;

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
		GUI.Label(new Rect(Screen.width/2, Screen.height/2,10,10), "+",style3);

		if (timeLeft == totalTime) {
			GUI.Label (new Rect (Screen.width/2, Screen.height/6, 100, 50), "<color=blue>S</color><color=magenta>P</color><color=blue>L</color><color=magenta>A</color><color=blue>T</color><color=magenta>T</color><color=blue>E</color><color=magenta>R</color> <color=blue>W</color><color=magenta>O</color><color=blue>R</color><color=magenta>L</color><color=blue>D</color>", style4);
			GUI.Label (new Rect (Screen.width/2, Screen.height / 3, 10, 10), "Use space to shoot and WASD to move\nAim for fruit and floating cubes\nBeware of trees\nShoot to start", style2);
		}

		if (timeLeft <= 0) {
			if (score > highscore) {
				highscore = score;
				PlayerPrefs.SetInt ("High Score", (int)highscore);
			}
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 4, 10, 10), "Game Over!\n"+"Your Score: "+score+"\nHigh Score: "+highscore+"\nPress Return to restart\nPress Escape to quit", style2);
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

			GameObject spawnedTree = (GameObject)Instantiate(tree, new Vector3 (x, 0, z), Quaternion.identity);
			spawnedTree.GetComponent<Tree> ().r = this;
			spawnedTree.GetComponent<Tree> ().init ();
		}
	}
}
