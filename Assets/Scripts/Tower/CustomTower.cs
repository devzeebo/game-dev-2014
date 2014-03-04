using UnityEngine;
using System.Collections;

public class CustomTower : MonoBehaviour {

	public GameObject towerBase;

	public GameObject towerModule;

	public GameObject towerWeapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject Spawn (Vector3 location) {

		GameObject baseObj = (GameObject)GameObject.Instantiate(towerBase, location, Quaternion.identity);
		GameObject modObj = (GameObject)GameObject.Instantiate(towerModule, location, Quaternion.identity);
		GameObject weapObj = (GameObject)GameObject.Instantiate(towerWeapon, location, Quaternion.identity);

		modObj.transform.parent = baseObj.transform;
		weapObj.transform.parent = modObj.transform;

		baseObj.GetComponent<TowerBase>().module = modObj.GetComponent<TowerModule>();
		modObj.GetComponent<TowerModule>().weapon = weapObj.GetComponent<TowerWeapon>();

		return baseObj;
	}
}
