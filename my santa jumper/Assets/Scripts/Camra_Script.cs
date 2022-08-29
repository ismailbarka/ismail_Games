using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camra_Script : MonoBehaviour {


	private float new_Distance;
	private float old_Distance;
	private float speed = 1f;
	public GameObject cameraUp;


	void Awake()
	{
		
	}

	void OnEnable()
	{
		PlayerController.StepUp += Move_Came;
	}

	void OnDisable()
	{
		PlayerController.StepUp -= Move_Came;
	}

	void Move_Came()
	{
		cameraUp.SetActive (true);
	}
}
