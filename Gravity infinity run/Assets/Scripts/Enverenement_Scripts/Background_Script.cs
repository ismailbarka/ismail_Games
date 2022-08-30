using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Script : MonoBehaviour {
	
	private float speed = 1.0f;

	void Update () 
	{
		Vector3 temp = transform.position;
		temp.x -= speed * Time.deltaTime;
		transform.position = temp;

		if (transform.position.x <= -10)
		{
			temp.x = 14f;
			transform.position = temp;
		}
	}
}
