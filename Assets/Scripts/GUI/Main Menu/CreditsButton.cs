using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {
	public bool InCredits = false;
	public bool GetInCredits()
	{
		return InCredits;
	}
	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown() {
		// do something
		InCredits = true;
			//Application.LoadLevel("SomeLevel");
		}
	// Update is called once per frame
	void Update () {
	
	}
}
