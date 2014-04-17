using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        // Menu Selection Window
        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.0f), this.Width(.25f), this.Height(.166f)), "Tower Customize"))
        {
            Debug.Log("Goto Level Select");
            Application.LoadLevel("Tower Customizer");
        }
        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.166f), this.Width(.25f), this.Height(.166f)), "Level Select"))
        {
            Debug.Log("Clicked the button with an image");
            Application.LoadLevel("Level Select");
        }
        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.333f), this.Width(.25f), this.Height(.166f)), "Achievements"))
        {
            Debug.Log("Clicked the button with an image");
            Application.LoadLevel("Achievements");
        }
        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.5f), this.Width(.25f), this.Height(.166f)), "Unlocks"))
        {
            Debug.Log("Clicked the button with an image");
            Application.LoadLevel("Unlocks");
        }
        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.666f), this.Width(.25f), this.Height(.166f)), "Shops"))
        {
            Debug.Log("Clicked the button with an image");
            Application.LoadLevel("Shops");
        }
        /*
        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.833f), this.Width(.25f), this.Height(.166f)), "Back"))
        {
            Debug.Log("Clicked the button with an image");
        }
        //*/
            }
}
