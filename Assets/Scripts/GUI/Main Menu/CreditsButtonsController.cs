using UnityEngine;
using System.Collections;

public class CreditsButtonsController : MonoBehaviour {
	static private float buttonheight;
	private static GameObject staticObject;
	public static bool Active {
		set {
			staticObject.SetActive(value);
		}
	}
    float ButtonHeight(int ButtonNumber) {
        return this.Height(.2f) + buttonheight * ButtonNumber;
    }
	// Use this for initialization
	void Start () {
		staticObject = gameObject;
		Active=false;
        buttonheight = this.Height(.2f);
	}
	void OnGUI(){

        if (GUI.Button(this.CenteredRect(this.Width(.5f), ButtonHeight(3), buttonheight, buttonheight), "Back"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
			//Active = true;
			MainMenuButtonsController.Active=true;
			Active=false;
			
		}
        if (GUI.Button(this.CenteredRect(this.Width(.5f), ButtonHeight(1), buttonheight, buttonheight), "Game By: \n Eric Zebonac\nJimmee Garcia\nPJ Ernstes"))
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
