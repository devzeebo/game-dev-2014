using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour {

	private Path path;

	private PathNode next;

	public float speed;

	// Use this for initialization
	void Start () {
		path = GameObject.Find("Path").GetComponent<Path>();
		next = path.FirstNode;
	}
	
	// Update is called once per frame
	void Update () {
		if (next != null) {

			float distance = Vector2.Distance(gameObject.transform.position, next.position);

			gameObject.LookAt2D(next.position);
			distance = gameObject.Move(speed, distance);

			if (distance > 0) {
				next = next.nextNode;

				if (next != null) {
					gameObject.LookAt2D(next.position);
					gameObject.Move(speed, distance);
				}
			}
		}
	}
}
