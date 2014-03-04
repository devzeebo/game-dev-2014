using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float moveSpeed = 0.1f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(new Vector3(moveSpeed, 0));
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate(new Vector3(0, -moveSpeed));
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(new Vector3(-moveSpeed, 0));
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(new Vector3(0, moveSpeed));
		}
	}
}
