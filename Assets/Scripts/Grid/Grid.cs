using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	private GameObject[,] towers;
	public int height = 10;
	public int width = 15;
	public Vector3 offsetVector = new Vector3(7.5f,5,10);
	// Use this for initialization
	void Start () {
		towers = new GameObject[width,height]; 
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

    public GameObject GetAt(int x, int y) {
        return towers[x, y];
    }

	public bool PlaceTower(GameObject tower, Vector3 position) {
		GameObject spawnedObject = null;
		Vector2 gridPos = ScreenToGridPosition(position);
		//Debug.Log(gridPos);
		if(gridPos.x >= width || gridPos.y >= height || gridPos.x < 0 || gridPos.y < 0)
		{
			Debug.Log("Outisde Grid");
		}
		else if(towers[(int)gridPos.x,(int)gridPos.y] == null)
		{
			spawnedObject = tower.GetComponent<CustomTowerBehaviour>().Spawn(GridToWorldPosition(gridPos));
			towers[(int)gridPos.x,(int)gridPos.y] = spawnedObject;
		}
		else
		{
			Debug.Log("Tower Already Placed.");
		}
		return spawnedObject != null;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
