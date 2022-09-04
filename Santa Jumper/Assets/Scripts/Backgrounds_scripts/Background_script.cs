using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_script : MonoBehaviour {

	private GameObject cam;


	void Awake ()
	{
		cam = GameObject.Find ("Main Camera");
	}
	

	void Update ()
	{
		
		if (transform.position.y < cam.transform.position.y - 11.656f)
		{
			Vector3 temp = transform.position;
			temp.y += 23.312f;
			transform.position = temp;
		}	

	}




}
