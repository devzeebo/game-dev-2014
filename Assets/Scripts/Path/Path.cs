using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

    private List<PathNode> nodes;

	public GameObject PathTemplate;

	private Grid grid;

	// Use this for initialization
	void Start () {
        nodes = new List<PathNode>();

		grid = GameObject.Find("Global").GetComponent<Grid>();

		Vector2 lastGameObject = Vector2.zero;
        PathNode last = null;

		List<GameObject> spawnedObjects = new List<GameObject>();

        for (int x = 0; x < transform.childCount; x++) {
			GameObject child = transform.GetChild(x).gameObject;
            PathNode next = new PathNode(child.transform.position, child);

			Vector2 childPos = grid.WorldToGridPosition(child.transform.position);
			grid.PutAt((int)childPos.x, (int)childPos.y, child);
			spawnedObjects.AddRange(PlaceExtraGameObjects(lastGameObject, childPos));

            nodes.Add(next);
            if (last != null) {
                last.nextNode = next;
            }
			last = next;
			lastGameObject = childPos;
        }

        last = nodes[nodes.Count - 1];
        for (int x = nodes.Count - 2; x >= 0; x--) {
            PathNode next = new PathNode(nodes[x].position, nodes[x].obj);
            nodes.Add(next);
            last.nextNode = next;
			last = next;
        }

		FirstNode = nodes[0];

		foreach (GameObject go in spawnedObjects) {
			go.transform.parent = transform;
		}
	}

	private List<GameObject> PlaceExtraGameObjects(Vector2 position, Vector2 nextPosition) {

		List<GameObject> list = new List<GameObject>();

		if (position == Vector2.zero) {
			position = nextPosition;
		}

		if (position.x > nextPosition.x) {
			position.x += nextPosition.x;
			nextPosition.x = position.x - nextPosition.x;
			position.x = position.x - nextPosition.x;
		}
		if (position.y > nextPosition.y) {
			position.y += nextPosition.y;
			nextPosition.y = position.y - nextPosition.y;
			position.y = position.y - nextPosition.y;
		}

		for (int x = (int)position.x; x <= nextPosition.x; x++) {
			for (int y = (int)position.y; y <= nextPosition.y; y++) {
				if (grid.GetAt(x, y) == null) {
					GameObject pathObject = (GameObject)GameObject.Instantiate(PathTemplate, grid.GridToWorldPosition(new Vector2(x, y)), Quaternion.identity);
					list.Add(pathObject);
					grid.PutAt(x, y, pathObject);
				}
			}
		}

		return list;
	}

	public PathNode FirstNode {
		get;
		private set;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
