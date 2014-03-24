using UnityEngine;
using System.Collections.Generic;

public class DroneTower : TowerBase {

	public List<Drone> drones = new List<Drone>();

	public GameObject Drone;

	public int NumberOfDrones {
		get { return drones.Count;  }
		set {
			if (drones.Count > value) {
				for (int i = value; i < drones.Count; i++) {
					Destroy(drones[i].gameObject);
					drones.RemoveAt(i--);
				}
			}
			else if (value > drones.Count) {
				GameObject newDrone = (GameObject)GameObject.Instantiate(Drone, transform.position, Quaternion.identity);
				drones.Add(newDrone.GetComponent<Drone>());
			}
		}
	}

	void Start() {
		base.Start();
	}

	public override bool AttackCheck(GameObject other) {
		return false;
	}

	protected override void PerformUpdate() {

		List<Drone> availableDrones = drones.FindAll((drone) => drone.target == null);
		if (availableDrones.Count > 0) {
			SortTargets();
			List<GameObject> enemies = targets.FindAll(obj => drones.ConvertAll(drone => drone.target).Contains(obj));

			for (int i = 0; i < availableDrones.Count; i++) {
				if (enemies.Count > 0) {
					availableDrones[i].target = enemies[0];
					enemies.RemoveAt(0);
				}
			}
		}
	}
}
