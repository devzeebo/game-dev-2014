using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour {

	public Path path;

	private PathNode next;

	public float speed;

	// Use this for initialization
	void Start () {
		path = GameObject.Find("Path").GetComponent<Path>();
		next = path.FirstNode;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(gameObject.transform.position, next.position);

		while (distance > 0) {
			distance = gameObject.Move(speed, distance);

			if (distance > 0) {
				next = next.nextNode;
			}
		}
	}
}
