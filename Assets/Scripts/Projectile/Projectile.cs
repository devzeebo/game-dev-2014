using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private float Damage;

	public float speed = 3f;
	Vector3 origin;

	// Use this for initialization
	void Start () {
		origin = transform.position;
	}

	public void SetDamage(float damage) {
		Damage = damage;
	}

	// Update is called once per frame
	void Update () {

		if (destroy) {
			Destroy(gameObject);
		}
		else {
			if (Vector2.Distance(gameObject.transform.position, origin) > 10) {
				Destroy(gameObject);
			}

			gameObject.Move(speed);
		}
	}

	void OnTriggerEnter2D(Collider2D other)   {
		if (other != null && other.gameObject != null && other.gameObject.GetComponent<Health>() != null) {
			other.gameObject.GetComponent<Health>().Damage(Damage);
		}
		Destroy(gameObject);
	}

	private bool destroy;

	public void DestroyNextUpdate() {
		destroy = true;
	}
}

