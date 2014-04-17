using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackTracker : MonoBehaviour {

	private bool backPushed;
    public List<int> SceneTracker = new List<int>();

	private int currentLevel;

	public void Backup() {
		if (SceneTracker.Count > 0) {
			backPushed = true;
			Application.LoadLevel(Pop());
		}
	}

	public int Pop() {
		int ret = SceneTracker[SceneTracker.Count - 1];
		SceneTracker.RemoveAt(SceneTracker.Count - 1);
		return ret;
	}

	public void Push(int level) {
		SceneTracker.Add(level);
	}

	public int Peek() {
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

		if (!backPushed && currentLevel != x) {
			Push(currentLevel);
			currentLevel = x;
		}
		backPushed = false;

		Print();
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
