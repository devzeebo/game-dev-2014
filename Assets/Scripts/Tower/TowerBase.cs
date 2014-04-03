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

	private SphereCollider Range;

	public int MaxTargets = 1;

	public bool IsOnCooldown {
		get {
			return attackCooldown > 0;
		}
	}

	// Use this for initialization
	public virtual void Start () {

		Range = gameObject.AddComponent<SphereCollider>();
		Range.isTrigger = true;

		UpdateRange(range);
	}

	public void UpdateRange(float range) {
		Range.radius = range;
	}

	protected void SortTargets() {
		targets.Sort( (go1, go2) =>
			(int)Mathf.Sign(Vector2.Distance(go1.transform.position, transform.position) - Vector2.Distance(go2.transform.position, transform.position))
		);
	}

	// Update is called once per frame
	void Update () {

		attackCooldown -= Time.deltaTime;

		targets.RemoveAll( go => go == null );

		PerformUpdate();
	}

	protected virtual void PerformUpdate() {
		SortTargets();

		int targetsRemaining = MaxTargets;

		if (!IsOnCooldown && targets.Count > 0) {
			for (int i = 0; i < targets.Count; i++) {

				if (targetsRemaining == 0) {
					break;
				}

				if (targets[i] != null) {
					if (AttackCheck(targets[i])) {
						Attack(targets[i]);
						targetsRemaining--;
					}
				}
				else {
					targets.RemoveAt(i);
					i--;
				}
			}

			attackCooldown = GetAttackSpeed();
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "enemy") {
			targets.Add(col.gameObject);
			OnEnemyEnter(col.gameObject);
		}
	}

	protected virtual void OnEnemyEnter(GameObject obj) {

	}

	void OnTriggerExit(Collider col) {
		if (targets.Contains(col.gameObject)) {
			targets.Remove(col.gameObject);
			OnEnemyExit(col.gameObject);
		}
	}

	protected virtual void OnEnemyExit(GameObject obj) {

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
