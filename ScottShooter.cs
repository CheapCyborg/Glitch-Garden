using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScottShooter : MonoBehaviour {

	public GameObject Projectile, Gun;

	private GameObject ProjectileParent;

	private void Start()
	{
		ProjectileParent = GameObject.Find("Projectiles");

		if (!ProjectileParent)
		{
			ProjectileParent = new GameObject("Projectiles");
		}
	}

	private void Fire()
	{
		GameObject newProjectile = Instantiate(Projectile);
		newProjectile.transform.parent = ProjectileParent.transform;
		newProjectile.transform.position = Gun.transform.position;
	}
}
