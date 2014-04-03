using UnityEngine;
using System.Collections;

public class CustomTowerBehaviour : MonoBehaviour {

	public CustomTower customTower;

	public CustomTowerBehaviour() {
		customTower = new CustomTower();
	}

	public GameObject towerBase {
		get {
			return customTower.towerBase;
		}
		set {
			customTower.towerBase = value;
		}
	}

	public GameObject towerModule {
		get {
			return customTower.towerModule;
		}
		set {
			customTower.towerModule = value;
		}
	}

	public GameObject towerWeapon {
		get {
			return customTower.towerWeapon;
		}
		set {
			customTower.towerWeapon = value;
		}
	}

	public GameObject Spawn(Vector3 location) {
		return customTower.Spawn(location);
	}
}
