using UnityEngine;
using System.Collections;

public class LeaveSceneTimer : MonoBehaviour {
    private int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        counter++;
        if (counter > 100) { Application.LoadLevel("Main Menu"); }
	}

    void OnGUI()
    {
       // GUIStyle FlashText =new GUIStyle();
       // GUI.Label(new Rect(this.Width(.5f), this.Height(.5f), this.Width(.2f), this.Height(.2f)), "Fluff Command");
    }
}
