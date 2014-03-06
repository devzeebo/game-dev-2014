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
		if(GameObject.Find("enemy") != null){
			enemy = GameObject.Find("enemy");
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(attackCooldown);


		if(enemy.gameObject != null) {
			module.gameObject.LookAt2D(enemy);
			if (Vector3.Distance(transform.position, enemy.transform.position)<range){
				Attack();
			}
		}
		else
		{
			Vector3 center = new Vector3(0,0,0);
			module.gameObject.LookAt2D(center);
		}
	}

    float GetAttackDamage() {
        return module.weapon.attackDamage * module.attackDamageMultiplier * attackDamageMultiplier;
    }

    float GetAttackSpeed() {
		return 100f / (attackSpeedMultiplier * module.attackSpeed * module.weapon.attackSpeedMultiplier);
    }

	void Attack() {

		attackCooldown = 100f / (attackSpeedMultiplier * module.attackSpeed * module.weapon.attackSpeedMultiplier);

		GameObject bullet = (GameObject)GameObject.Instantiate(module.weapon.projectilePrototype, transform.position, Quaternion.identity);
		bullet.LookAt2D(enemy);
	}
}
