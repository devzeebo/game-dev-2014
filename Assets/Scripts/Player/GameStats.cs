using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour {

	public float CashPerSecond = 5f;

	public float Cash = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Cash += CashPerSecond * Time.deltaTime;
	}

	void OnGUI() {
		GUI.Label(this.CenteredRect(this.Width(.8f), this.Height(.1f), this.Width(.1f), this.Height(.1f)), "" + ((int)Cash));
	}
}
