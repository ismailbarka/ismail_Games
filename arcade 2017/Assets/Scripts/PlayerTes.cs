using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTes : MonoBehaviour 
{

	public GameObject rocket;
	private Rigidbody2D myBody;
	private Animator anime;
	private bool canwalk, canShoot;
	private float speed;
	private float maxVelocity;
	private float force;
	private float velocity;
	private float timaBetweenShoots;

	// Use this for initialization
	void	Awake () 
	{
		instantiateVariables ();
	}
	
	// Update is called once per frame
	void	Update () 
	{
		PlayerMouvements ();
	}

	void	PlayerMouvements()
	{
		float h = Input.GetAxis ("Horizontal");

		if (canwalk) 
		{
			if (h > 0) {
				velocity = Mathf.Abs (myBody.velocity.x);
				if (velocity < maxVelocity)
					speed = force;
				gameObject.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				anime.SetBool ("Walk", true);
			} else if (h < 0) {
				velocity = Mathf.Abs (myBody.velocity.x);
				if (velocity < maxVelocity)
					speed = -force;
				gameObject.transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
				anime.SetBool ("Walk", true);
			} else if (h == 0) 
			{
				speed = 0f;
				anime.SetBool ("Walk", false);
			}
			myBody.AddForce (new Vector2 (speed, 0),ForceMode2D.Force);
		}
		if (canShoot == true) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				Vector3 shootpos = gameObject.transform.position;
				shootpos.y += 1.5f;
				Instantiate (rocket, shootpos, Quaternion.identity);
				canShoot = false;
				canwalk = false;
				anime.Play ("Shoot");
				StartCoroutine (ShootWaitDilay ());
			}
		}

	}

	void	instantiateVariables()
	{
		myBody = GetComponent<Rigidbody2D> ();
		anime = GetComponent<Animator> ();
		canwalk = true;
		canShoot = true;
		speed = 0f;
		force = 4.5f;
		maxVelocity = 4f;
		velocity = 0;
		timaBetweenShoots = 0.2f;
	}

	IEnumerator ShootWaitDilay()
	{
		yield return new WaitForSeconds(timaBetweenShoots);
		canShoot = true;
		canwalk = true;
	}

	IEnumerator KillThePlayerAndRestartTheGame()
	{
		transform.position = new Vector3 (200, 200, 0);
		yield return new WaitForSeconds (1.5);
		Application.LoadLevel (Application.LoadLevelName);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		string[] name= col.name.Split();

		if (name.Length > 1)
		{
			if(name[1] == "Ball")
			{
				StartCoroutine(KillThePlayerAndRestartTheGame());
			}
		}
	}

}
