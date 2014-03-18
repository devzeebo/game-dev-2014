using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerSelectionMenu : MonoBehaviour {

	public List<CustomTower> towers;

    void displayTowers() {
        // while not end of list, create tower object along bottom of screen

    }
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		instance = this;

		//towers = new List<CustomTower>(8);
	}

	private static TowerSelectionMenu instance;
	public static TowerSelectionMenu Instance {
		get {
			return instance;
		}
		private set {
			instance = value;
		}
	}

	public CustomTower this[int x] {
		get {
			return towers[x];
		}
		set {
			towers[x] = value;
		}
	}
}
