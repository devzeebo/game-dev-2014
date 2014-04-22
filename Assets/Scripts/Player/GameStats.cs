using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour {

	public float CashPerSecond = 5f;

	public float Cash = 100;

	private static GameStats instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		Cash += CashPerSecond * Time.deltaTime;
	}

	void OnGUI() {
		GUI.Label(this.CenteredRect(this.Width(.8f), this.Height(.1f), this.Width(.1f), this.Height(.1f)), "" + ((int)Cash));
	}

	public static void CollectBounty(float amount) {
		instance.Cash += amount;
	}

	public static bool BuyTower(float cost) {
		return instance.BuyTowerInstance(cost);
	}

	private bool BuyTowerInstance(float cost) {
		if (Cash < cost) {
			return false;
		}

		Cash -= cost;
		return true;
	}
}
