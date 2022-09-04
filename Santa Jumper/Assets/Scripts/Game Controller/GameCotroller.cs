using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCotroller : MonoBehaviour {

	public static GameCotroller instance;

	[SerializeField] private GameObject Platform;

	private float Distance_Between_Platforms = 4.1f;
	[HideInInspector] public int countPlatforms;
	[HideInInspector] public float lastPlatformPositionY = 2.1f;

	// Use this for initialization
	void Awake ()
	{
		MakeSignLeton ();
		Creat_platform_number_two ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnDisable()
	{
		instance = null;
	}

	private void MakeSignLeton()
	{
		if (instance == null) 
		{
			instance = this;
		}
	}

	public void CreatePlatform()
	{
		
		lastPlatformPositionY += Distance_Between_Platforms;
		GameObject newPlatform = Instantiate (Platform);
		newPlatform.transform.position = new Vector3 (0, lastPlatformPositionY, 0);
		newPlatform.name = "Platform" + countPlatforms;

		countPlatforms++;
	}

	void Creat_platform_number_two()
	{
		GameObject newPlatform = Instantiate (Platform);
		newPlatform.transform.position = new Vector3 (0, 2.1f, 0);
		newPlatform.name = "Platform" + countPlatforms;
		countPlatforms++;
	}

	public void Replay()
	{
		SceneManager.LoadScene ("GamePlay");
	}
}
