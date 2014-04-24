using UnityEngine;
using System.Collections;

public class Fire : Projectile {

	public float DamagePerSecond;

	public float effectTime;

	public override void HitEnemy(GameObject enemy) {

		FireEffect effect;
		if ((effect = enemy.GetComponent<FireEffect>()) == null) {
			effect = enemy.AddComponent<FireEffect>();
		}

		effect.DamagePerSecond = DamagePerSecond;
		effect.timeRemaining = effectTime;
		effect.experienceComponents = experienceComponents;
	}
}
