using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_platform : MonoBehaviour
{

	void Update () {
		if (transform.position.y < GameObject.Find ("Main Camera").transform.position.y - 7.0f )
		{
			Destroy (gameObject);
		}
		
	}
}
