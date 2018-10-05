using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] spawnAttacker;

	private GameObject Parent;

	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in spawnAttacker)
		{
			if(isTimeToSpawn(thisAttacker))
			{
				Spawn(thisAttacker);
			}
		}
	}

	bool isTimeToSpawn(GameObject attackerGameObject)
	{
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		float spawnDelay = attacker.seenEverySeconds;
		float spawnsPerSeconds = 1 / spawnDelay;

		if(Time.deltaTime > spawnDelay)
		{
			Debug.LogWarning("Spawn rate capepd by frame rate");
		}

		float threshold = spawnsPerSeconds * Time.deltaTime / 5;

		return (Random.value < threshold);
	}

	void Spawn(GameObject Attacker)
	{
		GameObject myAttacker = Instantiate(Attacker) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
}
