using UnityEngine;
using System.Collections;
using System;

public static class Utilities {
	private static DateTime _1970 = new DateTime(1970, 1, 1);

    private static Vector3 ScreenToWorldScale = new Vector3(1, 1, -0.1f);
	public static Vector3 ScreenToWorld(Vector2 screen)
	{
        Vector3 pos = Camera.main.ScreenToWorldPoint(screen);
        pos.Scale(ScreenToWorldScale);
        return pos;
	}

	public static Vector2 WorldToScreen (Vector3 world)
	{
		return Camera.main.WorldToScreenPoint(world);
	}

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

    public static void Move(this GameObject obj, float velocity) {
		Move(obj, velocity, Time.deltaTime);
    }

	public static void Move(this GameObject obj, float velocity, float time) {
		obj.transform.Translate(Vector3.right * velocity * time, Space.Self);
	}

	public static void MoveUntil(this GameObject obj, float velocity, float time, float maxDistance, MoveCallback callback) {

		while (time > 0) {
			float distance = Math.Min(velocity * time, maxDistance);
			float timeUsed = distance / velocity;
			time -= timeUsed;
			obj.Move(velocity, timeUsed);

			if (distance == maxDistance) {
				maxDistance = callback();

				if (maxDistance <= 0) {
					break;
				}
			}
		}
	}

	public delegate float MoveCallback();

	public delegate void CooldownCallback(float timeRemaining);

	public static float Cooldown(float cooldown, float speed, CooldownCallback callback) {

		float time = Time.deltaTime;

		while (time > 0) {
			time -= cooldown;

			if (time >= 0) {
				callback(time);
				cooldown = speed;
			}
		}

		return speed + time;
	}
}
