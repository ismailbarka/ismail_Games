using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

	private float minX, MaxX;

	void Start ()
	{
		Vector3 coor = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width,Screen.height, 0));
		minX = -coor.x + 0.25f;
		MaxX = coor.x - 0.25f;
	}

	void Update ()
	{
		Vector3 temp = transform.position;
		if (temp.x > MaxX)
			temp.x = MaxX;
		if (temp.x < minX)
			temp.x = minX;
		transform.position = temp;	
	}
}
