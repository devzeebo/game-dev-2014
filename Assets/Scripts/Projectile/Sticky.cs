using UnityEngine;
using System.Collections;

public class Sticky : Projectile {

	public float initialSpeed;

	public float effectTime;
	public float speedModifier;

	public override void HitEnemy(GameObject enemy) {

		StickyEffect effect;
		if ((effect = enemy.GetComponent<StickyEffect>()) == null) {
			effect = enemy.AddComponent<StickyEffect>();
		}

		effect.speedModifier = speedModifier;
		effect.timeRemaining = effectTime;
	}
}
