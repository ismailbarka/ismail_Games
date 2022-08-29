using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {


	public void PlayGame()
	{
		string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		GameManager.instance.index = int.Parse (name);
		SceneManager.LoadScene ("GamePlay");
	}

	void Start () {
		
	}
	

	void Update () {
		
	}
}
