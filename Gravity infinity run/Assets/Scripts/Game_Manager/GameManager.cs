using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Button[] buttons;
	public string level = "normal";

	void Start ()
	{
		DontDestroyOnLoad (this.gameObject);
	
		buttons[0].onClick.AddListener (() => Easy ());
		buttons[1].onClick.AddListener (() => Medium ());
		buttons[2].onClick.AddListener (() => Hard ());
	}
	
	void Easy()
	{
		level = "Easy";
		print (level);
	}
	void Medium()
	{
		level = "Medium";
		print (level);
	}

	void Hard()
	{
		level = "Hard";
		print (level);
	}

	public void LoadGamePlayScene()
	{
		SceneManager.LoadScene ("GamePlay");
	}


}
