using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform player;
	public float minX, maxX;
		
	
	// Update is called once per frame
	void Update () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		Vector3 temp = transform.position;
		temp.x = player.position.x;
		temp.y = player.position.y + 3.3f;
		if (temp.x < minX)
			temp.x = minX;
		else if (temp.x > maxX)
			temp.x = maxX;
		else
			transform.position = temp;
	}
}
