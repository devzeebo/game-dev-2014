using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerButton : MonoBehaviour {

    public TowerController controller;

	public Vector2 scrollPosition = Vector2.zero;

	static private int screenwidth = 1365;
	static private int screenheight = 595;
	private Rect WholeScreen = new Rect(0, 0, screenwidth, screenheight);
	private Rect LeftQuarter = new Rect (0,0,screenwidth/4, screenheight/4);
	private Rect offscreen2 = new Rect (0,0,screenwidth/4,screenheight);
	private Rect RightQuarter = new Rect(3*screenwidth/4, 0, screenwidth -3*screenwidth/4, screenheight);
	private Rect offscreen = new Rect(screenwidth-30, 0, screenwidth, screenheight);
	public List<GameObject> TowerComponents;
    public string Module;
	private List<GameObject> spawnedObjects;

	void Start() {
        controller = GameObject.Find("Tower Customizer Controller").GetComponent<TowerController>();
		spawnedObjects = new List<GameObject>(TowerComponents.Count);

		for(int i = 0; i < TowerComponents.Count; i++) {
            spawnedObjects.Add((GameObject)GameObject.Instantiate(TowerComponents[i], Vector3.zero, Quaternion.identity));
            spawnedObjects[i].transform.parent = transform;
		}
	}

	// this code modified from http://docs.unity3d.com/Documentation/ScriptReference/GUI.Button.html
	void OnGUI() {
	//	this code modified from:	http://docs.unity3d.com/Documentation/ScriptReference/GUI.BeginScrollView.html

		for(int i=0;i<TowerComponents.Count;i++)
		{
			Vector2 position = new Vector2(this.Width(.85f),this.Height(0.25f*(i+1)));
			spawnedObjects[i].transform.position = Utilities.ScreenToWorld(position);
			if(GUI.Button(this.CenteredRect(position.x, position.y, this.Height(.2f), this.Height(.2f)),""))
			{
                controller.SetComponent(Module, TowerComponents[i]);
			}
		}
		
	}

	public void UpdateComponent (GameObject prefab)
	{

	}
}