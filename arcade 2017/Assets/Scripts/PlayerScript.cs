using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	private GameObject rocket;
	[SerializeField]
	private AudioClip shootSound;

	private float speed = 9f;
	private float maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anime;

	private bool canShoot;
	private bool canWalk;

	// Use this for initialization
	void Awake () 
	{
		InistializeVariables();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Shoot ();
	}
	void FixedUpdate () 
	{
		PlayerWalk ();
	}
	void InistializeVariables ()
	{
		myBody = GetComponent<Rigidbody2D> ();
		anime = GetComponent<Animator> ();
		canShoot = true;
		canWalk = true;
	}

	void Shoot()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			if (canShoot == true) 
			{
				StartCoroutine (ShootTheRockt());
			}
		}
	}

	IEnumerator ShootTheRockt()
	{
		canShoot = false;
		anime.Play ("Shoot");

		Vector3 temp = transform.position;
		temp.y += 1f;

		Instantiate (rocket, temp, Quaternion.identity);


		yield return new WaitForSeconds (0.2f);
		canShoot = true;
	}

	void PlayerWalk()
	{
		var force = 0f;
		var velocity = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxis ("Horizontal");

		if (canWalk == true) 
		{
			if (h > 0) {
				//mouve right
				if (velocity < maxVelocity) 
				{
					force = speed;
				}
				Vector3 scale = transform.localScale;
				scale.x = 1;
				transform.localScale = scale;

				anime.SetBool ("Walk", true);
			}
			else if (h < 0) 
			{
				if (velocity < maxVelocity) 
				{
					force = -speed;
				}
				Vector3 scale = transform.localScale;
				scale.x = -1;
				transform.localScale = scale;
				anime.SetBool ("Walk", true);

			}
			else if (h == 0) 
			{
				anime.SetBool ("Walk", false);
			}
			myBody.AddForce (new Vector2 (force, 0));
		}

	}

}
