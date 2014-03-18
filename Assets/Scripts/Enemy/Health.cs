using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float maxHealth = 100;
	[HideInInspector]
	public float health;
	public GameObject HealthBar;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		HealthBar = (GameObject)GameObject.Instantiate(HealthBar, transform.position, Quaternion.identity);
		HealthBar.transform.parent = transform;
		HealthBar.transform.position -= new Vector3(0, -0.7f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		HealthBar.transform.localScale = new Vector3(health/ maxHealth, 1f);
	}

	public float Damage(float damage) {
		health -= damage;
		if (health <= 0) {
			Destroy(gameObject);
		}
		return health;
	}
}
