using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Controller : MonoBehaviour {

	private float moving_speed;
	private bool is_moving_right;
	private float max_X;

	private void Instantiate_variables()
	{
		moving_speed = 2.0f;
		max_X = 2.8f;
		int ran = Random.Range (0, 2);
		if (ran == 0)
			is_moving_right = false;
		else
			is_moving_right = true;
	}
	void Awake ()
	{
		Instantiate_variables ();
	}


	void Update () 
	{
		Move_Platform ();
	}

	private void Move_Platform()
	{
		if (is_moving_right == true) {
			Vector3 temp = this.transform.position;
			temp.x += moving_speed * Time.deltaTime;
			this.transform.position = temp;
			if (this.transform.position.x >= max_X)
			{
				is_moving_right = false;
			}
		}
		else if (is_moving_right == false)
		{
			Vector3 temp = this.transform.position;
			temp.x -= moving_speed * Time.deltaTime;
			this.transform.position = temp;
			if (this.transform.position.x <= -max_X)
			{
				is_moving_right = true;
			}
		}
	}



}
