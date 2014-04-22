using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour {

	public Path path;

	public List<SpawnInfo> spawns;

	List<GameObject> enemies;

	public float cooldown;

	// Use this for initialization
	void Start () {

		spawns = new List<SpawnInfo>();
		enemies = new List<GameObject>();
		List<Wave> waves = new List<Wave>();

		for (int x = 0; x < transform.childCount; x++) {
			waves.Add(transform.GetChild(x).GetComponent<Wave>());
		}
		waves.Sort((a, b) => a.gameObject.name.CompareTo(b.gameObject.name));

		for (int i = 0; i < waves.Count; i++) {
			InitSpawnInfo(waves[i]);
		}
	}

	void InitSpawnInfo(Wave wave) {
		
		if (wave.Enemy != null) {

			if (enemies.Find(obj => obj.name.Equals(wave.Enemy.name)) == null) {
				enemies.Add(wave.Enemy);
			}

			int idx = enemies.FindIndex(obj => obj.name.Equals(wave.Enemy.name));

			for (int i = 0; i < wave.repeatCount; i++) {
				spawns.Add(new SpawnInfo(idx, wave.spawnSpeed));
			}
		}

		Debug.Log("CHILD WAVES: " + wave.waves.Count);

		for (int r = 0; r < wave.repeatCount; r++) {
			for (int i = 0; i < wave.waves.Count; i++) {
				InitSpawnInfo(wave.waves[i]);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if (cooldown <= 0) {
			Spawn(spawns[0].go);
			cooldown = spawns[0].cooldown;
			spawns.RemoveAt(0);

			if (spawns.Count == 0) {
				gameObject.SetActive(false);
			}
		}
	}

	void Spawn(int idx) {
		GameObject.Instantiate(enemies[idx], path.FirstNode.position - new Vector3(1, 0, 0), Quaternion.identity);
	}

	public struct SpawnInfo {
		public int go;
		public float cooldown;

		public SpawnInfo(int go, float cd) {
			this.go = go;
			cooldown = cd;
		}
	}
}
