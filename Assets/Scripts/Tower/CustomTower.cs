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

        if (towerBase != null)
        {
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
