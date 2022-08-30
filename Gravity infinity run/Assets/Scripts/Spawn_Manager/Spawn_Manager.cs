using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour {

	public GameObject[] prefabs;
	public GameManager gameManager;

	[SerializeField] float min_Time;
	[SerializeField] float max_Time;
	private float x_pos = 7.0f;
	private float y_pos = 1.8f;

	// Use this for initialization
	void Start ()
	{
		gameManager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();
		if(gameManager.level == "Easy")
		{
			min_Time = 2.0f;
			max_Time = 4.0f;
		}
		else if(gameManager.level == "Medium")
		{
			min_Time = 1.0f;
			max_Time = 3.0f;
		}
		else if(gameManager.level == "Hard")
		{
			min_Time = 0.2f;
			max_Time = 1.5f;
		}
			
		StartCoroutine (Instantiate_Objects ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	IEnumerator Instantiate_Objects()
	{
		yield return new WaitForSeconds (Random.Range (min_Time, max_Time));


		GameObject new_Object = Instantiate(prefabs [Random.Range(0,2)]);
		new_Object.transform.position = new Vector3 (x_pos, Random.Range (-y_pos, y_pos));
		StartCoroutine (Instantiate_Objects ());
	}
}
