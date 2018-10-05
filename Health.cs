using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float health = 150f;

	public void dealDamage (float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			//optionally trigger animation
			DestroyObject();
		}
	}

	public void DestroyObject()
	{
		Destroy(gameObject);
	}
}
