using UnityEngine;
using System.Collections.Generic;

public class HUD : MonoBehaviour {

	private static HUD instance;

	public string message;

	private Rect InfoCenterRect;

	public GUIStyle RightAlignLabel;

	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy(instance);
		}
		instance = this;

		Vector2 botLeft = GUIUtilities.WorldToGuiScreen(new Vector3(-7.5f, 5, 0));
		Vector2 botRight = GUIUtilities.WorldToGuiScreen(new Vector3(7.5f, 5, 0));

		InfoCenterRect = this.CenteredRect(this.Width(.5f), botLeft.y / 2, botRight.x - botLeft.x, botLeft.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		GUI.Box(InfoCenterRect, "");

		GUI.Label(this.AnchoredRect(
			GUIUtilities.RIGHT_MID,
			InfoCenterRect.width + InfoCenterRect.xMin - this.Width(.07f, InfoCenterRect.width),
			InfoCenterRect.height / 2,
			this.Width(.07f, InfoCenterRect.width),
			InfoCenterRect.height
			), "Money: ", RightAlignLabel);

		GUI.Label(this.AnchoredRect(
			GUIUtilities.RIGHT_MID,
			InfoCenterRect.width + InfoCenterRect.xMin,
			InfoCenterRect.height / 2,
			this.Width(.05f, InfoCenterRect.width),
			InfoCenterRect.height
			), "" + GameStats.Money, RightAlignLabel);


	}

	private void TowerMessage() {

	}
}
