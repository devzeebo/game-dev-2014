using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour {

	public List<Wave> waves;
	public GameObject Enemy;

	public float spawnSpeed;

	public int repeatCount = 1;
	
	// Use this for initialization
	void Start () {
		waves = new List<Wave>();

		for (int x = 0; x < transform.childCount; x++) {
			waves.Add(transform.GetChild(x).GetComponent<Wave>());
		}
		waves.Sort((a, b) => a.gameObject.name.CompareTo(b.gameObject.name));
	}
}
