using UnityEngine;
using System.Collections;

public class apples : MonoBehaviour {

	public GameObject Tree;
	public GameObject Apple;
	private Vector3 pos;

	public void init(Vector3 pos) {
		Instantiate (Tree);
		Tree.transform.position = pos;
		this.pos = pos;

		initApples (new Vector3(pos.x + 1.5, 5.8, pos.z + 3));
		initApples (new Vector3(pos.x + 0.5, 12.5, pos.z - 1));
		initApples (new Vector3(pos.x - 2.5, 7.2, pos.z));
		initApples (new Vector3(pos.x + 1, 5, pos.z - 3));
		initApples (new Vector3(pos.x + 2.3, 8, pos.z));
		initApples (new Vector3(pos.x, 9.7, pos.z + 2));
		initApples (new Vector3(pos.x - 3, 4, pos.z - 2));
		initApples (new Vector3(pos.x + 3.4, 3.4, pos.z - 0.3));
			
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

		Instantiate (Apple, ApplePos);
	}
		

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}
}
