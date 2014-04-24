using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour {

	[HideInInspector]
	public Path path;

	private PathNode next;

	public float speed;

	public int nodeCount = 0;

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
			
			gameObject.MoveUntil(speed, Time.deltaTime, distance, () => {

				nodeCount++;
				next = next.nextNode;
				if (next == null) {
					Pickup pickup = null;
					if ((pickup = GetComponent<Pickup>()) != null) {
						Destroy(pickup.Collectable);
					}
					Destroy(gameObject);
					return 0;
				}

				gameObject.LookAt2D(next.position);
				return Vector2.Distance(gameObject.transform.position, next.position);
			});
		}
	}

	public bool isReturning() {
		return nodeCount > path.Count / 2;
	}

	public void Return() {
		if (!isReturning()) {
			next = path.nodes[path.Count - nodeCount];
			gameObject.LookAt2D(next.position);
		}
	}
}
