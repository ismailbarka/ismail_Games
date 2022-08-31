using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay_COntroller : MonoBehaviour {

	[SerializeField] private GameObject pausePanel;

	void Awake ()
	{
		pausePanel.SetActive (false);
	}
	

	public void Pause_Game ()
	{
		Time.timeScale = 0.0f;
		pausePanel.SetActive (true);
	}

	public void Resume_Game()
	{
		Time.timeScale = 1.0f;
		pausePanel.SetActive (false);
	}
	public void Quit_Game()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("MainMenu");
	}
}
