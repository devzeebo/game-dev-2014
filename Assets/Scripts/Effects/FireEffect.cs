using UnityEngine;
using System.Collections;

public class FireEffect : MonoBehaviour
{
	public float DamagePerSecond;

    public float timeRemaining;

	private Health health;

	public string[] experienceComponents;

	void Start() {
		health = gameObject.GetComponent<Health>();
	}

    // Update is called once per frame
    void Update()
    {
		health.Damage(DamagePerSecond * Mathf.Min(Time.deltaTime, timeRemaining), experienceComponents);

        if ((timeRemaining -= Time.deltaTime) < 0) {
            DestroyImmediate(this);
			return;
        }
    }
}
