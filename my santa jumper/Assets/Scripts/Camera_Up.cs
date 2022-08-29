using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Up : MonoBehaviour {

	private float new_Distance;
	private float old_Distance;
	public GameObject Camera_To_Up;
	private float speed = 10.0f;
	// Use this for initialization
	void OnEnable () 
	{
		new_Distance = old_Distance = Camera_To_Up.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 came_pos ;
		if (new_Distance <= old_Distance + 4.1f) {
			new_Distance += speed * Time.deltaTime;
			came_pos = Camera_To_Up.transform.position;
			came_pos.y = new_Distance;
			Camera_To_Up.transform.position = came_pos;
		} else
			gameObject.SetActive (false);
			
	}
}
