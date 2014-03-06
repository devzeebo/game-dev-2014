using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button(new Rect(this.Width(0.1f), this.Height(0), this.Width(0.1f), this.Height(0.05f)), "Back")) {
			Application.LoadLevel(1);
		}
	}
}
