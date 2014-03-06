using UnityEngine;
using System.Collections;

public class CreditsButtonsController : MonoBehaviour {
	static private int screenwidth = 1365;
	static private int screenheight = 595;
	static private int buttonheight = 100;
	private static GameObject staticObject;
	public static bool Active {
		set {
			staticObject.SetActive(value);
		}
	}
	// Use this for initialization
	void Start () {
		staticObject = gameObject;
		Active=false;
	}
	void OnGUI(){

		if (GUI.Button(new Rect(screenwidth/2-buttonheight/2 , screenheight/2-buttonheight/2+buttonheight*0, buttonheight, buttonheight), "Back"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
			//Active = true;
			MainMenuButtonsController.Active=true;
			Active=false;
			
		}
		if (GUI.Button(new Rect(screenwidth/2-buttonheight/2 , screenheight/2-buttonheight/2-buttonheight*1, buttonheight, buttonheight), "Game By: \n Eric Zebonac\nJimmee Garcia\nPJ Ernstes"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
			MainMenuButtonsController.Active=true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
