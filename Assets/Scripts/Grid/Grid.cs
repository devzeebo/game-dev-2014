using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	private GameObject[,] towers;
	public Vector3 offsetVector = new Vector3(7.5f,5,10);
	// Use this for initialization
	void Start () {
		towers = new GameObject[10,15];
	}

	public Vector2 ScreenToGridPosition(Vector3 vector)
	{
		vector = Camera.main.ScreenToWorldPoint(vector) + offsetVector;
		return new Vector2(Mathf.FloorToInt(vector.x),Mathf.FloorToInt(vector.y));
	}

	public Vector3 GridToWorldPosition(Vector2 vector)
	{
		return new Vector3(vector.x - offsetVector.x + 0.5f, vector.y - offsetVector.y + 0.5f, 0);
	}

	public Vector3 ScreenToWorldPosition(Vector3 vector) {
		return GridToWorldPosition(ScreenToGridPosition(vector));
	}

	// Update is called once per frame
	void Update () {
	
	}
}
