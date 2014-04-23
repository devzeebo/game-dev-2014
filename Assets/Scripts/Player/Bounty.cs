using UnityEngine;
using System.Collections;

public class Bounty : MonoBehaviour {

	public float Amount = 10;

	void OnDestroy() {
		GameStats.CollectBounty(Amount);
	}
}
