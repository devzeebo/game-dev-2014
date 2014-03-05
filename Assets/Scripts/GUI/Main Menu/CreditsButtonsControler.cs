using UnityEngine;
using System.Collections;

public class CreditsButtonsControler : MonoBehaviour {
	public static bool IsActive = false;
	
	static private int screenwidth = 1365;
	static private int screenheight = 595;
	static private int buttonheight = 100;

	// Use this for initialization
	void Start () {
		//gameObject.activeSelf(IsActive);
	}
	void OnGUI(){
		if (IsActive)
		{
			if (GUI.Button(new Rect(screenwidth/2-buttonheight/2 , screenheight/2-buttonheight/2+buttonheight*0, buttonheight, buttonheight), "Back"))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Debug.Log("Clicked the button with an image");
				//Active = true;
				IsActive = false;
				MainMenuButtonsControler.Active = true;
				
			}
			if (GUI.Button(new Rect(screenwidth/2-buttonheight/2 , screenheight/2-buttonheight/2-buttonheight*1, buttonheight, buttonheight), "Game By: \n Eric Zebonac\nJimmee Garcia\nPJ Ernstes"))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Debug.Log("Clicked the button with an image");
				MainMenuButtonsControler.Active = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
