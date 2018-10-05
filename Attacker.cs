using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	[Tooltip("Average of seconds between appearences")]
	public float seenEverySeconds;
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget)
		{
			anim.SetBool("isAttacking", false);
		}
	}

	public void setSpeed (float speed)
	{
		currentSpeed = speed;
	}

	// Called from the animator at the time of actual blow
	public void StrikeCurrentTarget(float damage)
	{
		if (currentTarget)
		{
			Health health = currentTarget.GetComponent<Health>();
			if(health)
			{
				health.dealDamage(damage);
			}
		}
	}

	public void attack (GameObject obj)
	{
		currentTarget = obj;
		
	}	
}