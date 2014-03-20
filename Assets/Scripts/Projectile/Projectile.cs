using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject enemy;

	private float Damage;

	public float speed = 3f;

	public float maxTime = 1000;

	protected long spawnTime;

	// Use this for initialization
	void Start () {
		spawnTime = Utilities.GetCurrentTimeMillis();
	}

	public void SetDamage(float damage) {
		Damage = damage;
	}

	// Update is called once per frame
	void Update () {

		Update(Time.deltaTime);

		if (CheckDestroy()) {
			Destroy(gameObject);
		}
		else {
			gameObject.Move(speed);
		}
	}

	protected virtual void Update(float deltaTime) {

	}

	void OnTriggerEnter(Collider other)   {
		if (other.tag == "enemy") {
			enemy.gameObject.GetComponent<Health>().Damage(Damage);
			HitEnemy(other.gameObject);
		}
	}

	public virtual void HitEnemy(GameObject enemy) {
		Destroy(gameObject);
	}

	public virtual bool CheckDestroy() {
		return Utilities.GetCurrentTimeMillis() - spawnTime > maxTime;
	}
}

