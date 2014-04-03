using UnityEngine;
using System.Collections;

public class WaveManager : Wave {

	public Path path;

	public GameObject EnemyPrefab;

	// Use this for initialization
	public override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if (cooldown <= 0) {
			cooldown = spawnSpeed;
			GameObject.Instantiate(EnemyPrefab, path.FirstNode.position - new Vector3(1, 0, 0), Quaternion.identity);
		}
	}
}
