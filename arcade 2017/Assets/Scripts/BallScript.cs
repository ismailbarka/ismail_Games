using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour 
{


	private float forceX, forceY;

	private Rigidbody2D myBody;

	[SerializeField] private bool moveLeft, moveRight;
	[SerializeField] GameObject originalBall;

	private GameObject ball1, ball2 ;
	private BallScript ball1Script, ball2Script;
	[SerializeField] AudioClip[] popSounds;

	// Use this for initialization
	void Awake () 
	{
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

	void OnTriggerEnter2D(Collider2D coll)
	{
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
			if (gameObject.tag != "Smallest Ball") {
				InstantiateBallsAndTurnOffCurrentBall ();
			}
			else
			{
				Destroy (gameObject);
			}
		}
	}
}