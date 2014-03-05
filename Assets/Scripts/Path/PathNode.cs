using UnityEngine;
using System.Collections;

public class PathNode {

    public Vector3 position;

    public PathNode nextNode;

    public PathNode(Vector3 vector) {
        position = vector;
    }
}
