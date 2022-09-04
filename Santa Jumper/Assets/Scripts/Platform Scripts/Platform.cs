using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private float speed  = 1f;

	private float boundLeft = -1.6f, boundRight = 1.6f;

	private bool left;

	// Use this for initialization
	void Awake () 
	{
		RandomizeMovement ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
		Destroy_platform ();
	}

	private void RandomizeMovement()
	{
		if (Random.Range (0, 2) == 0) {
			left = true;
		} else 
		{
			left = false;	
		}
	}

	private void Move()
	{
		if (left == true) {
			Vector3 temp = transform.position;
			temp.x = temp.x - (speed * Time.deltaTime);
			transform.position = temp;

			if (transform.position.x < boundLeft) 
			{
				left = false;
			}
		}
		else
		{
			Vector3 temp = transform.position;
			temp.x = temp.x + (speed * Time.deltaTime);
			transform.position = temp;

			if (transform.position.x > boundRight) 
			{
				left = true;
			}
		}
	}

	void Destroy_platform ()
	{
		if (transform.position.y < GameObject.Find ("Main Camera").transform.position.y - 7.0f )
		{
			Destroy (gameObject);
		}
	}
}
