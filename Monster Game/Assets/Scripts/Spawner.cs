using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField]
	private GameObject[] mounsterReference;

	private float minSpeed = 4.0f;
	private float maxSpeed = 8.0f;
	private float minInstantiateRate = 3.0f;
	private float maxInstantiateRate = 5.0f;
	void Awake()
	{
		
	}
	void Start ()
	{
		Invoke ("InstantiateEnemys", Random.Range (0.0f, 5.0f));
	}


	void InstantiateEnemys ()
	{
		GameObject monsster = Instantiate (mounsterReference [Random.Range (0, 2)],transform.position,Quaternion.identity);
		if (gameObject.name == "Left Spawner") {
			Vector3 spawnedLeftPrefab = monsster.transform.localScale;
			spawnedLeftPrefab.x = 1;
			monsster.transform.localScale = spawnedLeftPrefab;
			monsster.GetComponent<Enemy> ().speed = Random.Range (minSpeed, maxSpeed);
		}
		else if (gameObject.name == "Right Spawner")
		{
			Vector3 spawnedLeftPrefab = monsster.transform.localScale;
			spawnedLeftPrefab.x = -1;
			monsster.transform.localScale = spawnedLeftPrefab;
			monsster.GetComponent<Enemy> ().speed = Random.Range (-maxSpeed, -minSpeed);
		
		}
		Invoke ("InstantiateEnemys", Random.Range (minInstantiateRate, maxInstantiateRate));
	}
}
