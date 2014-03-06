using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int Damage(int damage)
	{
		health = health - damage;
		return damage;
	}
}
