using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerButton : MonoBehaviour {

    public TowerController controller;

	public Vector2 scrollPosition = Vector2.zero;
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
        //scrollPosition= GUI.BeginScrollView(new Rect(this.Width(.75f)+30,this.Height(0f),this.Width(.25f)-30,this.Height(.25f*(TowerComponents.Count+1))),scrollPosition,new Rect(this.Width(.75f)-30,this.Height(0f),this.Width(,25f)-30,this.Height(1f)));
		for(int i=0;i<TowerComponents.Count;i++)
		{
			Vector2 position = new Vector2(this.Width(.875f),this.Height(0.25f*(i+1)));
			spawnedObjects[i].transform.position = Utilities.ScreenToWorld(position);
			if(GUI.Button(this.CenteredRect(position.x, position.y, this.Height(.2f), this.Height(.2f)),TowerComponents[i].gameObject.name))
			{
                controller.SetComponent(Module, TowerComponents[i]);
			}
		}
        //GUI.EndScrollView();
		
	}

	public void UpdateComponent (GameObject prefab)
	{

	}
}