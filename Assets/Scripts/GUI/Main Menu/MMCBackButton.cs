using UnityEngine;
using System.Collections;

public class MMCBackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown() {
		// do something
		Camera.current.transform.Translate(new Vector3(100f, 0.0f, 0.0f));
		//Application.LoadLevel("SomeLevel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
