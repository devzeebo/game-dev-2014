using UnityEngine;
using System.Collections;

public class AoETower : TowerBase {

	void OnStart() {

	}

	public override void ModifyBullet(Projectile bullet) {
		base.ModifyBullet(bullet);

		bullet.speed = 0;
		bullet.transform.localScale = new Vector3(range, range, 0);
	}
}
