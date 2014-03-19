using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TowerBase : MonoBehaviour {

	public TowerModule module;

	[HideInInspector]
	public List<GameObject> targets;

	public float attackSpeedMultiplier = 1f;

	public float attackDamageMultiplier = 1f;

	public float attackCooldown;

	public float range = 5f;

	private CircleCollider2D Range;

	public bool IsOnCooldown {
		get {
			return attackCooldown > 0;
		}
	}

	protected GameObject ClosestTarget {
		get {
			return targets.OrderBy(go => 
				Vector2.Distance(go.transform.position, transform.position)
			).First();
		}
	}

	// Use this for initialization
	void Start () {

		GameObject other = new GameObject();
		other.AddComponent<CircleCollider2D>();
		other.transform.parent = transform;
		Range = other.GetComponent<CircleCollider2D>();
		Range.isTrigger = true;

		UpdateRange(range);
	}

	public void UpdateRange(float range) {
		Range.radius = range;
	}
	
	// Update is called once per frame
	void Update () {

		attackCooldown -= Time.deltaTime;

		if (!IsOnCooldown && targets.Count > 0) {
			for (int i = 0; i < targets.Count; i++) {
				if (AttackCheck(targets[i])) {
					Attack(targets[i]);
				}
			}

			attackCooldown = GetAttackSpeed();
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log(col.tag);
		if (col.gameObject.tag == "enemy") {
			targets.Add(col.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (targets.Contains(col.gameObject)) {
			targets.Remove(col.gameObject);
		}
	}

    float GetAttackDamage() {
        return module.weapon.attackDamage * module.attackDamageMultiplier * attackDamageMultiplier;
    }

    float GetAttackSpeed() {
		return 100f / (attackSpeedMultiplier * module.attackSpeed * module.weapon.attackSpeedMultiplier);
    }

	public GameObject SpawnProjectile() {
		GameObject bullet = (GameObject)GameObject.Instantiate(module.weapon.projectilePrototype, transform.position, Quaternion.identity);
		bullet.GetComponent<Projectile>().SetDamage(GetAttackDamage());
		return bullet;
	}

	public virtual void Attack(GameObject enemy) {
		
		GameObject bullet = SpawnProjectile();
		Projectile projectile = bullet.GetComponent<Projectile>();
		projectile.enemy = enemy;
		ModifyBullet(projectile);
	}

	public virtual bool AttackCheck(GameObject other) {
		
		return Vector2.Distance(transform.position, other.transform.position) < range;
	}

	public virtual void ModifyBullet(Projectile bullet) {
		bullet.gameObject.LookAt2D(bullet.enemy);
	}
}
