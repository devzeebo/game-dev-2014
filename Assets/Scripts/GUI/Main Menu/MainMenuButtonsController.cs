using UnityEngine;
using System.Collections;


public class MainMenuButtonsController : MonoBehaviour {
	static private float buttonheight;
	private static GameObject staticObject;
	public static bool Active {
		set {
			staticObject.SetActive(value);
		}
	}
	// Use this for initialization
	void Start () {
		staticObject = gameObject;
		Active=true;
        buttonheight = this.Height(.2f);
	}
    float ButtonHeight(int ButtonNumber) {
        return this.Height(.2f) + buttonheight * ButtonNumber;
    }
	void OnGUI(){

		// start button
        if (GUI.Button(this.CenteredRect(this.Width(.5f), ButtonHeight(0), buttonheight, buttonheight), "Start"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Application.LoadLevel(1);
			Debug.Log("Clicked the button with an image");
			
		}
		// Options Button
        if (GUI.Button(this.CenteredRect(this.Width(.5f), ButtonHeight(1), buttonheight, buttonheight), "Option"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("This button does nothing");
			Active = false;
			OptionsMenuController.Active = true;	
		}
		// Credits Button
        if (GUI.Button(this.CenteredRect(this.Width(.5f), ButtonHeight(2), buttonheight, buttonheight), "Credits"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
			Active = false;
			CreditsButtonsController.Active=true;
		}
		// Exit button
        if (GUI.Button(this.CenteredRect(this.Width(.5f), ButtonHeight(3), buttonheight, buttonheight), "Exit"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
			// use get component to get the prefab info for whichever prefab is selected
		}

	}

	// Update is called once per frame
	void Update () 
	{

			//gameObject.SetActive(false);
	}
}
