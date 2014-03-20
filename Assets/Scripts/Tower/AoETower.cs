using UnityEngine;
using System.Collections;

public class AoETower : TowerBase {

	void OnStart() {

	}

	public override void ModifyBullet(Projectile bullet) {
		base.ModifyBullet(bullet);

		bullet.updateFunction = (time) => {
			Color c = bullet.gameObject.GetComponent<SpriteRenderer>().color;
			bullet.gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, (1 - bullet.Age));
		};

		bullet.maxTime = 100;
		bullet.DestroyOnHit = false;
		bullet.speed = 0;
		bullet.transform.localScale = new Vector3(range, range, 0);
	}
}
