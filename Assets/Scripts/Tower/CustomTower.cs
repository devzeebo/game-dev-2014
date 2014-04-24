using UnityEngine;
using System.Collections;

public class CustomTower {

	public GameObject towerBase;

	public GameObject towerModule;

	public GameObject towerWeapon;

	public void CloneFrom(CustomTower tower) {
		towerBase = tower.towerBase;
		towerModule = tower.towerModule;
		towerWeapon = tower.towerWeapon;
	}

	public float Cost {
		get {
			return GetCost(towerBase) + GetCost(towerModule) + GetCost(towerWeapon);
		}
	}

	private float GetCost(GameObject obj) {
		return obj.GetComponent<ComponentCost>().Cost;
	}

	public GameObject Spawn(Vector3 location) {

		if (towerBase != null) {
			GameObject baseObj = (GameObject)GameObject.Instantiate(towerBase, location, Quaternion.identity);
			baseObj.name = towerBase.name;

			if (towerModule != null) {
				GameObject modObj = (GameObject)GameObject.Instantiate(towerModule, location, Quaternion.identity);
				modObj.transform.parent = baseObj.transform;
				modObj.name = towerModule.name;

				baseObj.GetComponent<TowerBase>().module = modObj.GetComponent<TowerModule>();

				if (towerWeapon != null) {
					GameObject weapObj = (GameObject)GameObject.Instantiate(towerWeapon, location, Quaternion.identity);
					weapObj.transform.parent = modObj.transform;
					weapObj.name = towerWeapon.name;

					modObj.GetComponent<TowerModule>().weapon = weapObj.GetComponent<TowerWeapon>();
				}
			}

			return baseObj;
		}
		return null;
	}
}
