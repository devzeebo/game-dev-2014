using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {

	public TowerModule module;

	public float attackSpeedMultiplier = 1f;

<<<<<<< HEAD
	public float attackDamageMultiplier = 1f;
=======
    public float attackDamageMultiplier = 1f;
>>>>>>> 9f1a1bfe05a37baa99c77af6c8bf71bfefb29bc9

	public float attackCooldown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 testCenter = new Vector3(0,0,0);
		module.gameObject.LookAt2D(testCenter);
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
