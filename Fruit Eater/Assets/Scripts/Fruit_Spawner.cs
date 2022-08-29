using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_Spawner : MonoBehaviour {

	[SerializeField] private GameObject[] fruits;
	private float x1,x2;
	private BoxCollider2D col;

	void Awake () 
	{
		col = GetComponent<BoxCollider2D> ();
		x1 = transform.position.x - col.bounds.size.x / 2.0f;
		x2 = transform.position.x + col.bounds.size.x / 2.0f;
	}

	void Start()
	{
		StartCoroutine (SpawnFruit (1));
	}
	
	IEnumerator SpawnFruit(float time)
	{
		yield return new WaitForSeconds (time);



		Vector3 temp = transform.position;
		temp.x = Random.Range (x1, x2);

		Instantiate (fruits [Random.Range (0, fruits.Length)], temp, Quaternion.identity);

		StartCoroutine (SpawnFruit (Random.Range (1f, 2f)));
	}
}
