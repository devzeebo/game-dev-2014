using UnityEngine;
using System.Collections;

public class FireEffect : MonoBehaviour
{

    public float initialSpeed;

    public float speedModifier;
    public float timeRemaining;

    // Use this for initialization
    void Start()
    {
        initialSpeed = gameObject.GetComponent<FollowPath>().speed;
        gameObject.GetComponent<FollowPath>().speed = gameObject.GetComponent<FollowPath>().speed * speedModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if ((timeRemaining -= Time.deltaTime) < 0)
        {
            gameObject.GetComponent<FollowPath>().speed = initialSpeed;
            DestroyImmediate(this);
        }
    }
}
