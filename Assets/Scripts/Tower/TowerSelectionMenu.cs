using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TowerSelectionMenu : MonoBehaviour {

	public GameObject defaultBase;
	public GameObject defaultModule;
	public GameObject defaultWeapon;

	public GameObject bg;

	public List<CustomTower> towers;
	public List<GameObject> towerInstances;

	private string file;

    void displayTowers() {
        // while not end of list, create tower object along bottom of screen
    }

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		instance = this;

		towerInstances = new List<GameObject>(8);
		towers = new List<CustomTower>(8);

		file = Application.dataPath + "/savedTowers";

		loadTowers();
	}

	public void RefreshTower(int index) {
		RefreshTower(index, towerInstances[index].transform.position);
	}

	public void RefreshTower(int index, Vector3 position) {
		GameObject obj = towers[index].Spawn(position);

		if (obj != null) {
			DontDestroyOnLoad(obj);
			obj.transform.parent = transform;
			obj.GetComponent<SpriteRenderer>().sortingLayerName = "HUD";
			foreach (MonoBehaviour script in obj.GetComponentsInChildren<MonoBehaviour>()) {
				Destroy(script);
			}
			foreach (SpriteRenderer renderer in obj.GetComponentsInChildren<SpriteRenderer>()) {
				renderer.sortingLayerName = "HUD";
			}
			CustomTowerBehaviour tower = obj.AddComponent<CustomTowerBehaviour>();
			tower.customTower.CloneFrom(towers[index]);

			if (towerInstances[index] != null) {
				Destroy(towerInstances[index]);
			}
			towerInstances[index] = obj;
			towers[index] = tower.customTower;
		}
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

	public void loadTowers() {

		/*
		if (File.Exists(file)) {
			StreamReader sr = new StreamReader(file);
			string[] lines = sr.ReadToEnd().Split('\n');
			sr.Close();

			foreach (string line in lines) {
				string[] kv = line.Split('=');

			}
		}
		else {
		//*/
			for (int i = 0; i < 8; i++) {
				towers.Add(new CustomTower());
				towers[i].towerBase = defaultBase;
				towers[i].towerModule = defaultModule;
				towers[i].towerWeapon = defaultWeapon;

				towerInstances.Add(new GameObject());

				RefreshTower(i, Vector3.zero);
				towerInstances[i].SetActive(false);
			}
		//}
	}
}
