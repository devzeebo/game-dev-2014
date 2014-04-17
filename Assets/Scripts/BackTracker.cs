using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackTracker : MonoBehaviour {

	private bool backPushed;
    public List<string> SceneTracker = new List<string>();

	private string currentLevel;

	public void Backup() {
		if (SceneTracker.Count > 1) {
			backPushed = true;
			Application.LoadLevel(Pop());
		}
	}

	public string Pop() {
		string ret = SceneTracker[SceneTracker.Count - 1];
		SceneTracker.RemoveAt(SceneTracker.Count - 1);
		return ret;
	}

	public void Push(string level) {
		SceneTracker.Add(level);
	}

	public string Peek() {
		return SceneTracker[SceneTracker.Count - 1];
	}

	private void Print() {
		string print = "";
		for (int i = 0; i < SceneTracker.Count; i++) {
			print += SceneTracker[i] + " ";
		}
		Debug.Log(print);
	}

	// Use this for initialization
	void Start () {
		
	}

	void OnLevelWasLoaded(int x) {
		Debug.Log("LEVEL " + x + " LOADED");
		Print();

		if (!backPushed && currentLevel != Application.loadedLevelName) {
			Push(currentLevel);
		}
		backPushed = false;
        currentLevel = Application.loadedLevelName;

		Print();
	}

    void OnGUI()
    {
        if (Application.loadedLevel < 1) { return; }

        if (GUI.Button(new Rect(this.Width(.0f), this.Height(.833f), this.Width(.25f), this.Height(.166f)), "Back"))
        {
            Debug.Log("Clicked the BackButton");
            Backup();
        }
    }
}
