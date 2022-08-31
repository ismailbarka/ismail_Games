using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] private GameObject[] tetrisObjects;
	void Start ()
	{
		SpawnRandom ();
	}
	
	// Update is called once per frame
	public void SpawnRandom ()
	{
		int index = Random.Range (0, tetrisObjects.Length);
		Instantiate (tetrisObjects [index], transform.position, Quaternion.identity);
	}
}
