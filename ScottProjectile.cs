﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScottProjectile : MonoBehaviour {
	public float speed, damage;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Defenders defenders = collision.gameObject.GetComponent<Defenders>();
		Health health = collision.gameObject.GetComponent<Health>();

		if (defenders && health)
		{
			health.dealDamage(damage);
			Debug.Log(name + " Dealt " + damage);
			Destroy(gameObject);
		}
	}
}
