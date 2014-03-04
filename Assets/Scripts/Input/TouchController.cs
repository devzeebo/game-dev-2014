using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InputHandler),typeof(Grid))]
public class TouchController : MonoBehaviour {

	private InputHandler handler;
	private Grid grid;
	public GameObject temp;
	// Use this for initialization
	void Start () {
		grid = GetComponent<Grid>();
		handler = GetComponent<InputHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		handler.handleInput();
		foreach(InputEvent e in handler.Events){
			if(e.phase == TouchPhase.Began){
				Debug.Log(temp);
				temp.GetComponent<CustomTower>().Spawn(grid.ScreenToWorldPosition(e.position));
			}
		}
	}
}