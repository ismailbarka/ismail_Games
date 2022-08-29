using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour 
{

	private Rigidbody2D myBody;
	private float speed = 5.0f;
	// Use this for initialization
	void Awake () 
	{
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		myBody.velocity = new Vector2 (0, speed);
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Top") 
		{
			Destroy (gameObject);
		}

		string[] name = target.name.Split ();
		if (name.Length > 1) 
		{
			if (name [1] == "Ball") 
			{
				Destroy (gameObject);
			}
		}
	}
}
