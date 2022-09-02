using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_particle : MonoBehaviour {

	void Awake()
	{
		StartCoroutine (Destroy_gameObkect ());
	}
	IEnumerator Destroy_gameObkect()
	{
		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
	}
}
