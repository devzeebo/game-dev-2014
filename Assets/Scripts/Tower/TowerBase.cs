using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {

	public TowerModule module;

	private GameObject enemy;

	public float attackSpeedMultiplier = 1f;

	public float attackDamageMultiplier = 1f;

	public float attackCooldown;

	public float range = 5f;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find("enemy");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(attackCooldown);
		module.gameObject.LookAt2D(enemy);
		if (Vector3.Distance(transform.position, enemy.transform.position)<range){
			Attack();
		}

	}

    float GetAttackDamage() {
        return module.weapon.attackDamage * module.attackDamageMultiplier * attackDamageMultiplier;
    }

    float GetAttackSpeed() {
        return module.attackSpeed * module.weapon.attackSpeedMultiplier * attackSpeedMultiplier;
    }

	void Attack() {

		attackCooldown = 100f / (attackSpeedMultiplier * module.attackSpeed * module.weapon.attackSpeedMultiplier);
		GameObject bullet = (GameObject)GameObject.Instantiate(module.weapon.projectilePrototype, transform.position, Quaternion.identity);
		float distance = Vector2.Distance(bullet.transform.position, enemy.transform.position);
		bullet.LookAt2D(enemy);
		distance = bullet.gameObject.Move(3f, distance);
		if (distance > 0) {
			bullet.gameObject.Move(3f, distance);
		}
	}
}
