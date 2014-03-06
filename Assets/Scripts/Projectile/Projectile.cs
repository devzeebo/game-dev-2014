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

		if (Vector2.Distance(gameObject.transform.position, origin) > 10) {
			Destroy(gameObject);
		}

		gameObject.Move(speed);
	}

	void OnTriggerEnter2D(Collider2D other)   {
		other.gameObject.GetComponent<Health>().Damage(Damage);
		Destroy(gameObject);
	}
}

