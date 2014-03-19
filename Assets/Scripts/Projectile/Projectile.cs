using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject enemy;

	private float Damage;

	public float speed = 3f;

	public float maxTime = 1000;

	protected float spawnTime;

	// Use this for initialization
	void Start () {
		spawnTime = Utilities.GetCurrentTimeMillis();
	}

	public void SetDamage(float damage) {
		Damage = damage;
	}

	// Update is called once per frame
	void Update () {

		if (CheckDestroy()) {
			Destroy(gameObject);
		}
		else {
			gameObject.Move(speed);
		}
	}

	void OnTriggerEnter2D(Collider2D other)   {
		if (other.tag == "enemy") {
			HitEnemy(other.gameObject);
		}
	}

	public virtual void HitEnemy(GameObject enemy) {
		enemy.gameObject.GetComponent<Health>().Damage(Damage);
	}

	public virtual bool CheckDestroy() {
		return Utilities.GetCurrentTimeMillis() - spawnTime > maxTime;
	}
}

