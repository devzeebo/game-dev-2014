using UnityEngine;
using System.Collections;
using System;

public static class Utilities {
	private static DateTime _1970 = new DateTime(1970, 1, 1);

	public static long GetCurrentTimeMillis() {
		return (long)((DateTime.UtcNow - _1970).TotalMilliseconds);
	}

	public static void LookAt2D(this GameObject tower, GameObject other) {
		tower.LookAt2D(other == null ? tower.transform.position : other.transform.position);
	}

	public static void LookAt2D(this GameObject tower, Vector3 vector) {

		float rotation = Mathf.Atan2(vector.y - tower.transform.position.y, vector.x - tower.transform.position.x);
		tower.transform.rotation = Quaternion.EulerAngles(0, 0, rotation);
	}

    public static float Move(this GameObject obj, float velocity) {
        obj.transform.Translate(Vector3.right * velocity * Time.deltaTime, Space.Self);
        return 0;
    }

    public static float Move(this GameObject obj, float velocity, float maxDistance) {
		float realDistance = velocity * Time.deltaTime;
		Debug.Log("Velocity: " + realDistance + ", Max: " + maxDistance);
        float distance = Math.Min(realDistance, maxDistance);
        obj.transform.Translate(Vector3.right * distance, Space.Self);

        return realDistance - maxDistance;
    }
}
