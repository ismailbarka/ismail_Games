using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCotroller : MonoBehaviour
{
	public GameObject newPlatform;
	private GameObject first_platform;
	private float last_platform_y_pos;

	private void Instantiate_variables()
	{
		first_platform = GameObject.Find ("First_Platform");
		last_platform_y_pos = first_platform.transform.position.y;
	}

	void Awake ()
	{

	}
	
	void Update ()
	{
		
	}

	void OnEnable()
	{
		PlayerController.StepUp += Instantiate_preafab;
	}

	void OnDisable()
	{
		PlayerController.StepUp -= Instantiate_preafab;
	}

	public void Instantiate_preafab()
	{
		last_platform_y_pos += 4.1f;
		GameObject newPlatformTemp = Instantiate (newPlatform);
		Vector3 temp = newPlatformTemp.transform.position;
		temp.y = last_platform_y_pos;
		newPlatformTemp.transform.position = temp;
	}

}
