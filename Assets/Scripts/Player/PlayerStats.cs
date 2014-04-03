using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

	public int TotalJunk;
	
	public Dictionary<string, float> TowerSpentExperience;
	public Dictionary<string, float> TowerTotalExperience;

	// Use this for initialization
	void Start () {

		instance = this;

		TowerSpentExperience = new Dictionary<string, float>();
		TowerTotalExperience = new Dictionary<string, float>();
	}

	private static PlayerStats instance;
	public static PlayerStats Instance {
		get {
			return instance;
		}
		private set {
			instance = value;
		}
	}

	public void AddExperience(string component, float amount) {
		if (!TowerTotalExperience.ContainsKey(component)) {
			TowerTotalExperience[component] = 0;
		}
		TowerTotalExperience[component] += amount;
	}
}
