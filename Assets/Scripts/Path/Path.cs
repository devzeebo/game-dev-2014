using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

    private List<PathNode> nodes;

	// Use this for initialization
	void Start () {
        nodes = new List<PathNode>();

        for (int x = 0; x < transform.childCount; x++) {
            nodes.Add(new PathNode());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
