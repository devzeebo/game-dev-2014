using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject Collectable = null;
	
	// Update is called once per frame
	void OnDestroy() {
		if (Collectable != null) {
			Collectable.transform.parent = null;
		}
	}

	void OnTriggerEnter(Collider other) {

		if (Collectable == null && other.tag == "collectable" && other.transform.parent == null) {
			Collectable = other.gameObject;
			Collectable.transform.parent = transform;
			Collectable.transform.localScale = new Vector3(1, 1, 0);
		}
	}
}
