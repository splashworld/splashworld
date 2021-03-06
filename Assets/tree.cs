using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	public Room r;
	public GameObject Apple;
	private Vector3 pos;

	private float counter = .5f;

	public void init() {
		
		pos = this.transform.position;

		initApples (new Vector3(pos.x + 1.5f, 5.8f, pos.z + 3f));
		initApples (new Vector3(pos.x + 0.5f, 12.5f, pos.z - 1f));
		initApples (new Vector3(pos.x - 2.5f, 7.2f, pos.z));
		initApples (new Vector3(pos.x + 1f, 5f, pos.z - 3f));
		initApples (new Vector3(pos.x + 2.3f, 8f, pos.z));
		initApples (new Vector3(pos.x, 9.7f, pos.z + 2f));
		initApples (new Vector3(pos.x - 3f, 4f, pos.z - 2f));
		initApples (new Vector3(pos.x + 3.4f, 3.4f, pos.z - 0.3f));
			
	}

	private void initApples(Vector3 ApplePos) {
		// apple1: 1.5, 5.8, 3
		// apple2: .5, 12.5, -1
		// apple3: -2.5, 7.2, 0
		// apple4: 1, 5, -3
		// apple5: 2.3, 8, 0
		// apple6: 0, 9.7, 2
		// apple7: -3, 4, -2
		// apple8: 3.4, 3.4, -0.3

		GameObject spawnedApple = (GameObject)Instantiate (Apple, ApplePos, Quaternion.identity);
		spawnedApple.transform.position = ApplePos;
		spawnedApple.gameObject.GetComponent<TargetBehavior> ().r = this.r;
	}
	// Update is called once per frame
	void Update () {
		if (counter <= 0) {
			gameObject.GetComponent<Renderer> ().material.color = Color.white;
			counter = .5f;
		} else if (gameObject.GetComponent<Renderer> ().material.color != Color.white){
			counter -= Time.deltaTime;
		}

	}

	void OnCollisionEnter (Collision newCollision)
	{

		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {
			gameObject.GetComponent<Renderer>().material.color = newCollision.gameObject.GetComponent<Renderer>().material.color;
			r.score--;
		}
	}
}
