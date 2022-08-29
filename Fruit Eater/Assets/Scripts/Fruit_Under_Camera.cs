using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_Under_Camera : MonoBehaviour {

	private Vector3 coor;

	// Use this for initialization
	void Start ()
	{
		coor = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width,Screen.height, 0));
		print (-coor.y);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject.transform.position.y < -coor.y - 1)
			Destroy (gameObject);
	}
}
