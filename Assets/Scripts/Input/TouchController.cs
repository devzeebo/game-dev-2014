using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(InputHandler),typeof(Grid))]
public class TouchController : MonoBehaviour {

	private InputHandler handler;
	private Grid grid;
	public GameObject temp;

	private List<GameObject> objs;

	// Use this for initialization
	void Start () {
		grid = GetComponent<Grid>();
		handler = GetComponent<InputHandler>();

		objs = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		handler.handleInput();

		foreach (GameObject obj in objs) {
			obj.LookAt2D(grid.ScreenToWorldPosition(Input.mousePosition));
		}

		foreach(InputEvent e in handler.Events){
			if(e.phase == TouchPhase.Began){
				Debug.Log(temp);
				grid.PlaceTower(temp, e.position);
			}
		}
	}
}