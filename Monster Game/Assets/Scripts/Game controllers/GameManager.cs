using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	[SerializeField] private GameObject[] players;

	[HideInInspector] public int index = 0;
	private bool spawned = false;



	// Use this for initialization
	void Awake () {
		MakeSingLeton ();
	}

	void Update()
	{
		OnlevelWasLoaded ();
	}

	void MakeSingLeton()
	{
		if (instance != null) {
			//Destroy gameObject;
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad (this); 
		}
	}

	void OnlevelWasLoaded()
	{
		if (SceneManager.GetActiveScene ().name == "GamePlay" && spawned == false) {
			Instantiate (players [index], new Vector3 (0.0f, -3.0f, 0.0f), Quaternion.identity);
			spawned = true;
		} else if (SceneManager.GetActiveScene ().name != "GamePlay" )
		{
			spawned = false;
		}
	}
}












