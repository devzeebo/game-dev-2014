using UnityEngine;
using System.Collections;


public class MainMenuButtonsControler : MonoBehaviour {

	static private int screenwidth = 1365;
	static private int screenheight = 595;
	static private int buttonheight = 100;
	public static bool Active = true;
	// Use this for initialization
	void Start () {

	}
	void OnGUI(){
		if (Active)
		{
			if (GUI.Button(new Rect(screenwidth/2-buttonheight/2 , screenheight/2-buttonheight/2-buttonheight*2, buttonheight, buttonheight), "Start"))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Application.LoadLevel(1);
				Debug.Log("Clicked the button with an image");
				
			}
			if (GUI.Button(new Rect(screenwidth/2-buttonheight/2 , screenheight/2-buttonheight/2-buttonheight*1, buttonheight, buttonheight), "Option"))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Debug.Log("This button does nothing");
				Active = false;
				OptionsMenuControler.IsActive = true;

				
			}
			if (GUI.Button(new Rect(screenwidth/2-buttonheight/2 , screenheight/2-buttonheight/2+buttonheight*0, buttonheight, buttonheight), "Credits"))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Debug.Log("Clicked the button with an image");
				Active = false;
				CreditsButtonsControler.IsActive = true;
				
			}
			if (GUI.Button(new Rect(screenwidth/2-buttonheight/2 , screenheight/2-buttonheight/2+buttonheight*1, buttonheight, buttonheight), "Exit"))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Debug.Log("Clicked the button with an image");
				// use get component to get the prefab info for whichever prefab is selected
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{

			//gameObject.SetActive(false);
	}
}
