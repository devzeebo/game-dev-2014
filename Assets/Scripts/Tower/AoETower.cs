using UnityEngine;
using System.Collections;

public class AoETower : TowerBase {
	
	public override void Attack() {

		attackCooldown = 100f / (attackSpeedMultiplier * module.attackSpeed * module.weapon.attackSpeedMultiplier);

		GameObject bullet = (GameObject)GameObject.Instantiate(module.weapon.projectilePrototype, transform.position, Quaternion.identity);

		bullet.transform.localScale += new Vector3(3f,3f,0);
		bullet.GetComponent<Projectile>().speed = 0;
		bullet.LookAt2D(enemy);
	}
}
