using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	private Rigidbody2D rb;
	private float jump_force;
	private Button jump_button;
	private bool can_jump;
	private GameCotroller game_controller;
	private Camera_move_up camera_move_up;
	[HideInInspector] public int player_score;
	public GameObject game_over_panel;
	private bool game_is_over; 

	void Instantiate_variables()
	{
		player_score = 0;
		can_jump = true;
		rb = GetComponent<Rigidbody2D> ();
		jump_force = 10.0f;
		jump_button = GameObject.Find ("Jump button").GetComponent<Button> ();
		game_controller = GameObject.Find ("Game Controller").GetComponent<GameCotroller> ();
		camera_move_up = GameObject.Find ("Main Camera").GetComponent<Camera_move_up> ();
		game_is_over = false;
	}

	void Awake()
	{
		Instantiate_variables ();
	}

	void Start()
	{
		jump_button.onClick.AddListener (Player_jump);
	}

	void Update()
	{
		if (transform.position.y < GameObject.Find ("Main Camera").transform.position.y - 7.0f )
		{
			Game_over();
		}
	}

	void Player_jump()
	{
		if (can_jump)
		{
			Vector2 temp_vel = rb.velocity;
			temp_vel.y = jump_force;
			rb.velocity = temp_vel;
			can_jump = false;
		}			
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (rb.velocity.y < 0.5f && rb.velocity.y > -0.5f)
		{
			can_jump = true;
			transform.SetParent (target.transform);
		}

		if ((rb.velocity.y < 0.5f && rb.velocity.y > -0.5f)
			&& target.gameObject.name == "Platform" + (game_controller.countPlatforms -1) &&
			GameObject.Find ("Platform" + (game_controller.countPlatforms)) == null) 
		{
			game_controller.CreatePlatform ();
			camera_move_up.enabled = true;
			player_score++;
		}
	}

	void OnCollisionExit2D(Collision2D target)
	{
		transform.SetParent (null);
	}

	void Game_over()
	{
		if (game_is_over == false)
		{
			game_over_panel.SetActive (true);
			game_is_over = true;
		}	

	}
}
	
















