using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text score;
	private PlayerScript player_script;

	void Awake ()
	{
		score = GetComponent<Text> ();
		player_script = GameObject.Find ("Player").GetComponent<PlayerScript> ();
	}
	

	void Update ()
	{
		score.text = "Score : " + player_script.player_score.ToString ();
	}
}
