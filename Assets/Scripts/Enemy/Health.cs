using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100;

	public GameObject HealthBar;

	// Use this for initialization
	void Start () {
		HealthBar = (GameObject)GameObject.Instantiate(HealthBar, transform.position, Quaternion.identity);
		HealthBar.transform.parent = transform;
		HealthBar.transform.position -= new Vector3(0, -0.7f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		HealthBar.transform.localScale = new Vector3(1f, health / 100);
	}

	public float Damage(float damage) {
		health -= damage;
		if (health <= 0) {
			Destroy(gameObject);
		}
		return health;
	}
}
