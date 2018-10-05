using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour {
	public GameObject Projectile, Gun;

	private GameObject ProjectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Update()
	{
		if (IsAttackerInLane())
		{
			animator.SetBool("isAttacking", true);
		}else
		{
			animator.SetBool("isAttacking", false);
		}
	}

	private void Start()
	{
		animator = GetComponent<Animator>();
		ProjectileParent = GameObject.Find("Projectiles");

		if (!ProjectileParent)
		{
			ProjectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}

	void SetMyLaneSpawner()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		foreach(Spawner spawner in spawnerArray)
		{
			if(spawner.transform.position.y == transform.position.y)
			{
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError(name + " Cant find spawner in lane");
	}

	private void Fire()
	{
		GameObject newProjectile = Instantiate(Projectile);
		newProjectile.transform.parent = ProjectileParent.transform;
		newProjectile.transform.position = Gun.transform.position;
	}

	bool IsAttackerInLane()
	{
		if (myLaneSpawner.transform.childCount <= 0)
		{
			return false;
		}

		foreach (Transform attacker in myLaneSpawner.transform)
		{
			if (attacker.transform.position.x > transform.position.x)
			{
				return true;
			}
		}
		return false;
	}
}
