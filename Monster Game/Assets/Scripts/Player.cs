using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public float moveForce = 5.0f, jumpForce = 10.0f, maxVelocity = 7f;
	private Rigidbody2D myBody;
	private Animator anim;
	private bool grounded= true;

	// Use this for initialization
	void Awake () 
	{
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		PlayerMoveKeyboard (); 
	}

	public void PlayerMoveKeyboard()
	{
		float forceX = 0f;
		float forceY = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);
		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {
			if (vel < maxVelocity) 
			{
				forceX = moveForce;
			}
			anim.SetBool ("Walk", true);
			Vector3 temp = transform.localScale;
			temp.x = 1f;
			transform.localScale = temp;
		} 
		else if (h < 0) {
			if (vel < maxVelocity) 
			{
				forceX = -moveForce;
			}
			anim.SetBool ("Walk", true);
			Vector3 temp = transform.localScale;
			temp.x = -1f;
			transform.localScale = temp;
		}
		else
		{
			anim.SetBool ("Walk", false);
		}

		if (grounded) 
		{
			if (Input.GetKey (KeyCode.Space))
			{
				forceY = jumpForce;
				grounded = false;
			} 
		}
		
		myBody.AddForce (new Vector2 (forceX, forceY));
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground") 
		{
			grounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Enemy") 
		{
			GameOver ();
		}
	}

	void GameOver()
	{
		gameObject.SetActive (false);
	}
}
