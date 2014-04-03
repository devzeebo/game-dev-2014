using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject enemy;

	private float Damage;

	public float speed = 3f;

	public float maxTime = 1000;

	public long spawnTime;

	public float Age {
		get {
			return (Utilities.GetCurrentTimeMillis() - spawnTime) / maxTime;
		}
	}

	public bool DestroyOnHit = true;

	public delegate void UpdateFunction(float deltaTime);
	public UpdateFunction updateFunction;

	public string[] experienceComponents;

	// Use this for initialization
	void Start () {
		spawnTime = Utilities.GetCurrentTimeMillis();
	}

	public void SetExperienceComponents(params string[] comps) {
		experienceComponents = comps;
	}

	public void SetDamage(float damage) {
		Damage = damage;
	}

	// Update is called once per frame
	void Update () {

		Update(Time.deltaTime);

		if (updateFunction != null)
		{
			updateFunction(Time.deltaTime);
		}

		if (DestroyAfterTime()) {
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
			other.gameObject.GetComponent<Health>().Damage(Damage, experienceComponents);
			HitEnemy(other.gameObject);

			if (DestroyOnHit) {
				Destroy(gameObject);
			}
		}
	}

	public virtual void HitEnemy(GameObject enemy) {
		
	}

	protected bool DestroyAfterTime() {
		return Age > 1;
	}
}

