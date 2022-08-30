using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Left : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Awake () 
	{
		if (speed == 0)
			speed = Random.Range (0.2f, 7.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 temp = transform.position;
		temp.x -= speed * Time.deltaTime;
		transform.position = temp;

		if (transform.position.x <= -10.0f) {
			Destroy (gameObject);
		}
	}
}
