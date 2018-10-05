using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scott : MonoBehaviour {

	public Animator anim;
	public Attacker attacker;

	// Use this for initialization
	void Start()
	{
		anim.GetComponent<Animator>();
		attacker.GetComponent<Attacker>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject obj = collision.gameObject;

		// Leave method if not colliding with defender
		if (!obj.GetComponent<Defenders>())
		{
			return;
		}
		anim.SetBool("isAttacking", true);
		attacker.attack(obj);
	}
}
