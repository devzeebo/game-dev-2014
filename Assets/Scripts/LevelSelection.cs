using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if (GUI.Button(this.CenteredRect(this.Width(.33f), this.Height(.5f), this.Width(.10f), this.Width(.10f)), "Spring"))
        {
            // level select 2
            Debug.Log("Clicked the button with an image");
            Application.LoadLevel("level-1");
        }
        if (GUI.Button(this.CenteredRect(this.Width(.5f), this.Height(.5f), this.Width(.10f), this.Width(.10f)), "Summer"))
        {
            // level select 4
          
            Debug.Log("Clicked the button with an image");
            Application.LoadLevel("Summer");
        }
        if (GUI.Button(this.CenteredRect(this.Width(.66f), this.Height(.5f), this.Width(.10f), this.Width(.10f)), "Winter"))
        {
            // level select 5
            Debug.Log("Clicked the button with an image");
            Application.LoadLevel("Winter");
        }
    }
}
