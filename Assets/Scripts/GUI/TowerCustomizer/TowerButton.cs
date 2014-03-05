using UnityEngine;
using System.Collections;

public class TowerButton : MonoBehaviour {
	public bool Selected = false;
	public GameObject prefab;
	public GameObject prefab2;
	public Vector2 scrollPosition = Vector2.zero;
	private Texture btnTexture;
	private Texture btnTexture2;
	private Texture btnTexture3;
	static private int screenwidth = 1365;
	static private int screenheight = 595;
	private Rect WholeScreen = new Rect(0, 0, screenwidth, screenheight);
	private Rect LeftQuarter = new Rect (0,0,screenwidth/4, screenheight/4);
	private Rect offscreen2 = new Rect (0,0,screenwidth/4,screenheight);
	private Rect RightQuarter = new Rect(3*screenwidth/4, 0, screenwidth -3*screenwidth/4, screenheight);
	private Rect offscreen = new Rect(screenwidth-30, 0, screenwidth, screenheight);

	private Rect current;
	private Rect current2;
	public bool hidden = false;
	public Texture getTexture()
	{
		return btnTexture3;
	}

	void Start() {
		current = RightQuarter;
		current2 = LeftQuarter;
		btnTexture = prefab.GetComponent<SpriteRenderer>().sprite.texture;
		btnTexture2 = prefab2.GetComponent<SpriteRenderer>().sprite.texture;
		btnTexture3 = btnTexture;
	}


	// this code modified from http://docs.unity3d.com/Documentation/ScriptReference/GUI.Button.html
	void OnGUI() {
		if (Selected)
		{
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		// display button
			/*
		if (GUI.Button(new Rect(screenwidth/2-50 , screenheight/4-50, 100, 100), btnTexture3))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
		}
		//*/
		/*
		if (GUI.Button(new Rect(10, 565, 50, 30), "Click"))
			Debug.Log("Clicked the button with text");
		//*/
		/*
		if (GUI.Button(new Rect(1300, 565, 65, 30), "Bottom Left Button"))
			Debug.Log("Clicked the button with text");
		//*/
		//	this code modified from:	http://docs.unity3d.com/Documentation/ScriptReference/GUI.BeginScrollView.html
		// left side menu
		scrollPosition = GUI.BeginScrollView(current, scrollPosition, new Rect(0, 0, screenwidth -3*screenwidth/4-20, screenheight*2));
		// hide and unhide button
			if (GUI.Button(new Rect(0,0,30,screenheight*2),"H\nI\nD\nE\n \nB\nU\nT\nT\nO\nN\n"))
		{
			if (hidden)
			{
				current = RightQuarter;
				hidden = false;
				// tell parent to set hide value in all children to something
			}
			else
			{
				current = offscreen;
				hidden = true;
				// tell tower controler to hide all the ones
			}
		}
		// component selection buttons
		if (GUI.Button(new Rect(100 , 50, 100, 100), btnTexture))
		{
			Debug.Log("Clicked the button with an image");
			btnTexture3=btnTexture;
		}
		if (GUI.Button(new Rect(100 , 200, 100, 100), btnTexture2))
		{
			Debug.Log("Clicked the button with an image");
			btnTexture3=btnTexture2;
		}
		if (GUI.Button(new Rect(100 , 350, 100, 100), btnTexture))
		{
			Debug.Log("Clicked the button with an image");
			btnTexture3=btnTexture;
		}
		if (GUI.Button(new Rect(100 , 500, 100, 100), btnTexture2))
		{
			Debug.Log("Clicked the button with an image");
			btnTexture3=btnTexture2;
		}
		if (GUI.Button(new Rect(100 , 650, 100, 100), btnTexture))
		{
			Debug.Log("Clicked the button with an image");
			btnTexture3=btnTexture;
		}
		if (GUI.Button(new Rect(100 , 800, 100, 100), btnTexture2))
		{
			Debug.Log("Clicked the button with an image");
			btnTexture3=btnTexture2;
		}
		if (GUI.Button(new Rect(100 , 950, 100, 100), btnTexture))
		{
			Debug.Log("Clicked the button with an image");
			btnTexture3=btnTexture;
		}
		if (GUI.Button(new Rect(100 , 1100, 100, 100), btnTexture2))
		{
			Debug.Log("Clicked the button with an image");
			btnTexture3=btnTexture2;
		}
		GUI.EndScrollView();
		}
	}
}