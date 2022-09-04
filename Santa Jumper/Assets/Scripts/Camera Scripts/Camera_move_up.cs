using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move_up : MonoBehaviour {

	private float Camera_move_speed;
	private GameCotroller game_controller;

	void Instantiate_variables()
	{
		game_controller = GameObject.Find ("Game Controller").GetComponent<GameCotroller> ();
		Camera_move_speed = 5.0f;
	}

	void Awake ()
	{
		Instantiate_variables ();
	}
	

	void Update ()
	{
		if (transform.position.y < game_controller.lastPlatformPositionY) {
			Vector3 temp = transform.position;
			temp.y += Camera_move_speed * Time.deltaTime;
			transform.position = temp;
		} else
			gameObject.GetComponent<Camera_move_up> ().enabled = false;
	}
}
