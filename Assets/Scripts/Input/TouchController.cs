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

		foreach(InputEvent e in handler.Events){
			if(e.phase == TouchPhase.Began){
				Debug.Log(temp);
				bool placed = grid.PlaceTower(temp, e.position);

                if (placed) {
                    Vector2 pos = grid.ScreenToGridPosition(e.position);
                    objs.Add(grid.GetAt((int)pos.x, (int)pos.y));
                }
			}
		}
	}
}