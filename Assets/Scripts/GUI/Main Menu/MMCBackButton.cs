using UnityEngine;
using System.Collections;

public class MMCBackButton : MonoBehaviour {
    public BackTracker BT;
	// Use this for initialization
	void Start () {
        //BT.UpdateStack(Application.loadedLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*
    void OnGUI()
    {
        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.833f), this.Width(.25f), this.Height(.166f)), "Back"))
        {
            Debug.Log("Clicked the button with an image");
            BT.Backup();
        }
    }
    //*/
}
