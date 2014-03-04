using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {

	public TowerModule module;

	float attackSpeedMultiplier = 1f;

	float attackDamageMultiplier = 1f;

	float attackCooldown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Attack() {
		attackCooldown = 100f / (attackSpeedMultiplier * module.attackSpeed * module.weapon.attackSpeedMultiplier);
	}
}
