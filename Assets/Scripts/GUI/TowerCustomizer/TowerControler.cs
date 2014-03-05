using UnityEngine;
using System.Collections;

public class TowerControler : MonoBehaviour {
	public GameObject TowerBase;
	public GameObject TowerModule;
	public GameObject TowerWeapon;
	public bool hidden2 = false;
	static private int screenwidth = 1365;
	static private int screenheight = 595;
	static private int buttonwidth = 30;
	private Rect RightQuarter = new Rect(3*screenwidth/4, 0, screenwidth -3*screenwidth/4, screenheight);
	// Use this for initialization
	void Start () {
		TowerBase.GetComponent<TowerButton>().Selected = true;
		TowerModule.GetComponent<TowerButton>().Selected = false;
		TowerWeapon.GetComponent<TowerButton>().Selected = false;
	
	}
	void OnGUI(){
		if (!TowerBase.GetComponent<TowerButton>().hidden &&!TowerModule.GetComponent<TowerButton>().hidden &&!TowerWeapon.GetComponent<TowerButton>().hidden)
		{
			if (GUI.Button(new Rect(screenwidth/2-50 , screenheight/2-100, 100, 100), TowerBase.GetComponent<TowerButton>().getTexture()))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");

		}
			if (GUI.Button(new Rect(screenwidth/2-50 , screenheight/2-100, 100, 100), TowerModule.GetComponent<TowerButton>().getTexture()))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Debug.Log("Clicked the button with an image");

			}
			if (GUI.Button(new Rect(screenwidth/2-50 , screenheight/2-100, 100, 100), TowerWeapon.GetComponent<TowerButton>().getTexture()))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Debug.Log("Clicked the button with an image");

			}
			if (GUI.Button(new Rect(screenwidth/2-50 , screenheight/2+100, 100, 100),"Save Tower"))
				// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
			{
				Debug.Log("Clicked the button with an image");
				TowerBase.GetComponent<TowerButton>().getTexture();
				TowerModule.GetComponent<TowerButton>().getTexture();
				TowerWeapon.GetComponent<TowerButton>().getTexture();
				// use get component to get the prefab info for whichever prefab is selected
			}
			if (GUI.Button(new Rect(3*screenwidth/4-buttonwidth , 2*screenheight/3, buttonwidth, screenheight/3), "b\na\ns\ne"))
		{
			Debug.Log("Clicked the button with an image");
			TowerBase.GetComponent<TowerButton>().Selected = true;
			TowerModule.GetComponent<TowerButton>().Selected = false;
			TowerWeapon.GetComponent<TowerButton>().Selected = false;
			//btnTexture3=btnTexture;
		}
			if (GUI.Button(new Rect(3*screenwidth/4-buttonwidth , screenheight/3, buttonwidth, screenheight/3), "m\no\nd\nu\nl\ne"))
		{
			Debug.Log("Clicked the button with an image");
			TowerBase.GetComponent<TowerButton>().Selected = false;
			TowerModule.GetComponent<TowerButton>().Selected = true;
			TowerWeapon.GetComponent<TowerButton>().Selected = false;
			//btnTexture3=btnTexture;
		}
			if (GUI.Button(new Rect(3*screenwidth/4-buttonwidth , 0, buttonwidth, screenheight/3), "w\ne\na\np\no\nn"))
		{
			Debug.Log("Clicked the button with an image");
			TowerBase.GetComponent<TowerButton>().Selected = false;
			TowerModule.GetComponent<TowerButton>().Selected = false;
			TowerWeapon.GetComponent<TowerButton>().Selected = true;
			//btnTexture3=btnTexture;
		}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
