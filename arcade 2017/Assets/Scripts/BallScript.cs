using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour 
{

	private Player_score player_score_script;
	private float forceX, forceY;

	private Rigidbody2D myBody;

	[SerializeField] private bool moveLeft, moveRight;
	[SerializeField] GameObject originalBall;
	[SerializeField] GameObject particle;
	[SerializeField] GameObject game_over_panel;

	private GameObject ball1, ball2 ;
	private BallScript ball1Script, ball2Script;
	[SerializeField] AudioClip[] popSounds;

	// Use this for initialization
	void Awake () 
	{
		player_score_script = GameObject.Find ("Score_text").GetComponent<Player_score> ();
		myBody = GetComponent<Rigidbody2D> ();
		SetBallSpeed ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveBall ();	
	}

	void InstantiateBalls()
	{
		if (this.gameObject.tag != "Smallest Ball") 
		{
			ball1 = Instantiate (originalBall);
			ball2 = Instantiate (originalBall);

			ball1.name = originalBall.name;
			ball2.name = originalBall.name;

			ball1Script = ball1.GetComponent<BallScript> ();
			ball2Script = ball2.GetComponent<BallScript> ();
		}
	}

	void InstantiateBallsAndTurnOffCurrentBall()
	{
		InstantiateBalls ();
		Vector3 tmp = transform.position;

		ball1.transform.position = tmp;
		ball1Script.SetMoveLeft (true);

		ball2.transform.position = tmp;
		ball2Script.SetMoveRight (true);

		ball1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 2.5f);
		ball2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 2.5f);
		Destroy (gameObject);
	}

	public void SetMoveLeft(bool newMoveLeft)
	{
		this.moveLeft = newMoveLeft;
		this.moveRight = !newMoveLeft;
	}

	public void SetMoveRight(bool newMoveRight)
	{
		this.moveRight = newMoveRight;
		this.moveLeft = !newMoveRight;
	}

	void SetBallSpeed()
	{
		forceX = 2.5f;
		switch (this.gameObject.tag) 
		{
		case "Largest Ball":
			forceY = 11.5f;
			break;
		case "Large Ball":
			forceY = 10.5f;
			break;
		case "Medium Ball":
			forceY = 9.0f;
			break;
		case "Small Ball":
			forceY = 8.0f;
			break;
		case "Smallest Ball":
			forceY = 7.0f;
			break;
		}
	}

	void MoveBall()
	{
		if (moveLeft) {
			Vector3 temp = transform.position;
			temp.x -= forceX * Time.deltaTime;
			transform.position = temp;
		}
		else if (moveRight) 
		{
			Vector3 temp = transform.position;
			temp.x += forceX * Time.deltaTime;
			transform.position = temp;
		}
	}

	private void Game_Over(GameObject coll)
	{
		GameObject temp_part = Instantiate (particle, coll.transform.position, Quaternion.identity);
		temp_part.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		Instantiate (game_over_panel);
		Destroy (coll.gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") 
		{
			Game_Over(coll.gameObject);
		}
		if (coll.tag == "Ground") 
		{
			myBody.velocity = new Vector2 (0, forceY);
		}
		if (coll.tag == "RightWall") 
		{
			SetMoveLeft (true);
		}
		if (coll.tag == "LeftWall") 
		{
			SetMoveRight (true);
		}
		if (coll.tag == "Rocket") 
		{
			player_score_script.score++;	
			if (gameObject.tag != "Smallest Ball") {
				
				InstantiateBallsAndTurnOffCurrentBall ();
			}
			else
			{
				GameObject temp_particle = Instantiate (particle, transform.position, Quaternion.identity);
				temp_particle.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
				Destroy (gameObject);
			}
		}
	}
}