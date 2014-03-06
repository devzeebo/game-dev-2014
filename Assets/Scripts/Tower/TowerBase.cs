using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {

	public TowerModule module;

	[HideInInspector]
	public GameObject enemy;

	public float attackSpeedMultiplier = 1f;

	public float attackDamageMultiplier = 1f;

	public float attackCooldown;

	public float range = 5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(enemy != null) {
			module.gameObject.LookAt2D(enemy);
			if (Vector3.Distance(transform.position, enemy.transform.position) < range){
				Attack();
			}
			else {
				enemy = null;
			}
		}
		
		if (enemy == null)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
			if (enemies.Length > 0) {
				GameObject closest = null;
				float distance = float.MaxValue;
				for (int x = 0; x < enemies.Length; x++) {
					float dist = Vector3.Distance(transform.position, enemies[x].transform.position);
					if (dist < distance) {
						distance = dist;
						closest = enemies[x];
					}
				}
				enemy = closest;
				module.gameObject.LookAt2D(enemy);
			}
		}
	}

    float GetAttackDamage() {
        return module.weapon.attackDamage * module.attackDamageMultiplier * attackDamageMultiplier;
    }

    float GetAttackSpeed() {
		return 100f / (attackSpeedMultiplier * module.attackSpeed * module.weapon.attackSpeedMultiplier);
    }

	public virtual GameObject SpawnProjectile() {
		GameObject bullet = (GameObject)GameObject.Instantiate(module.weapon.projectilePrototype, transform.position, Quaternion.identity);
		bullet.GetComponent<Projectile>().SetDamage(GetAttackDamage());
		return bullet;
	}

	public void Attack() {

		attackCooldown -= Time.deltaTime;

		Debug.Log(attackCooldown);
		if (attackCooldown < 0) {
			
			attackCooldown = GetAttackSpeed();

			GameObject bullet = SpawnProjectile();
			bullet.LookAt2D(enemy);
		}
	}
}
