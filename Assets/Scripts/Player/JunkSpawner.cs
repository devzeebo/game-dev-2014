using UnityEngine;
using System.Collections.Generic;

public class JunkSpawner : MonoBehaviour {

	public int NumberToSpawn = 10;
	public List<GameObject> Collectables;

	public float SpawnRadius = 1f;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < NumberToSpawn; i++) {
			GameObject obj = Collectables[Random.Range(0, Collectables.Count)];

			GameObject spawn = (GameObject)GameObject.Instantiate(obj, new Vector3(
				Random.Range(transform.position.x - SpawnRadius, transform.position.x + SpawnRadius),
				Random.Range(transform.position.y - SpawnRadius, transform.position.y + SpawnRadius),
				0), Quaternion.identity);
			spawn.name = "Collectable";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
