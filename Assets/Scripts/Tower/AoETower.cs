using UnityEngine;
using System.Collections;

public class AoETower : TowerBase {
	
	//public override GameObject SpawnProjectile() {

	//	GameObject bullet = base.SpawnProjectile();

	//	bullet.transform.localScale += new Vector3(3f,3f,0);
	//	bullet.GetComponent<Projectile>().speed = 0;

	//	StartCoroutine(KillBullet(bullet.GetComponent<Projectile>()));

	//	return bullet;
	//}

	//public IEnumerator KillBullet(Projectile go) {
	//	yield return new WaitForSeconds(0.01f);
	//	go.DestroyNextUpdate();
	//}
}
