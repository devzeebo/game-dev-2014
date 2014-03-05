using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {

	public TowerModule module;

	private GameObject enemy;

	public float attackSpeedMultiplier = 1f;

	public float attackDamageMultiplier = 1f;

	public float attackCooldown;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find("enemy");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(enemy.transform.position);
		module.gameObject.LookAt2D(enemy);
	}

    float GetAttackDamage() {
        return module.weapon.attackDamage * module.attackDamageMultiplier * attackDamageMultiplier;
    }

    float GetAttackSpeed() {
        return module.attackSpeed * module.weapon.attackSpeedMultiplier * attackSpeedMultiplier;
    }

	void Attack() {
		attackCooldown = 100f / (attackSpeedMultiplier * module.attackSpeed * module.weapon.attackSpeedMultiplier);
	}
}
