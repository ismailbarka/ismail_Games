using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[HideInInspector] public float speed;
	private Rigidbody2D myBody;

	void Awake()
	{

		myBody = GetComponent<Rigidbody2D> ();
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		myBody.velocity = new Vector2 (speed, 0);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Boundery") {
			Destroy (gameObject);
		}
	}
}











































