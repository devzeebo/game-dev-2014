using UnityEngine;
using System.Collections;

public class PathNode {

    public Vector3 position;

    public PathNode nextNode;

	public GameObject obj;

    public PathNode(Vector3 vector, GameObject obj) {
        position = vector;
		this.obj = obj;
    }
}
