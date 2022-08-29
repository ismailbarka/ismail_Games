using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movements : MonoBehaviour
{

	private float speed = 5.0f;
	private Rigidbody2D rb;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		Vector2 vel = rb.velocity;
		float h = Input.GetAxis ("Horizontal");
		vel.x = h * speed;
		rb.velocity = vel;
	}

} //class
