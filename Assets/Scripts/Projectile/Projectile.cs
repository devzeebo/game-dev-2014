using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private GameObject enemy;

	public float speed = 3f;
	Vector3 origin;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find("enemy");
		Vector3 center = new Vector3(0,0,0);
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector2.Distance(gameObject.transform.position, origin) > 3) {
			Destroy(gameObject);
		}

		gameObject.Move(speed);
	}

	void OnTriggerEnter2D(Collider2D other)   {
		Debug.Log("COLLIDE");
		//Destroy(other.gameObject);
	}
}

