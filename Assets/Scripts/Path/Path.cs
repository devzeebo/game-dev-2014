using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

    private List<PathNode> nodes;

	// Use this for initialization
	void Start () {
        nodes = new List<PathNode>();

        PathNode last = null;
        for (int x = 0; x < transform.childCount; x++) {
            PathNode next = new PathNode(transform.GetChild(x).position);
            nodes.Add(next);
            if (last != null) {
                last.nextNode = next;
            }
        }

        last = nodes[nodes.Count - 1];
        for (int x = nodes.Count - 2; x >= 0; x--) {
            PathNode next = new PathNode(nodes[x].position);
            nodes.Add(next);
            last.nextNode = next;
        }

		FirstNode = nodes[0];
	}

	public PathNode FirstNode {
		get;
		private set;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
