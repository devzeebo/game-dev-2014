using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackTracker : MonoBehaviour {
    bool newscene = false;
    public Stack<int> SceneTracker = new Stack<int>();
    public void UpdateStack(int x)
    {
        SceneTracker.Push(x);
    }
    public void Backup()
    {
        SceneTracker.Pop();
        Application.LoadLevel( SceneTracker.Peek());
    }   

	// Use this for initialization
	void Start () {
        Debug.Log("Last Loaded " + Application.loadedLevel);
        SceneTracker.Push(Application.loadedLevel);
	}
	
	// Update is called once per frame
	void Update () {
        // how to update which scene we've visited?
        //*
        if (SceneTracker.Peek() == Application.loadedLevel) 
        { newscene = false; }
        else 
        { newscene = true; }
        if (newscene) 
        { SceneTracker.Push(Application.loadedLevel); 
            newscene = false;
            
        }
//*/
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.833f), this.Width(.25f), this.Height(.166f)), "Back"))
        {
            Debug.Log("Clicked the button with an image");
            Backup();
        }
    }
}
