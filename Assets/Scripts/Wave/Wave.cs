using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour {

	public List<Wave> waves;

	public float spawnSpeed;

	public float cooldown;

	public List<Finished> callbacks;

	public delegate void Finished();
	
	// Use this for initialization
	public void Start () {
		waves = new List<Wave>();

		for (int x = 0; x < transform.childCount; x++) {
			waves.Add(transform.GetChild(x).GetComponent<Wave>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
