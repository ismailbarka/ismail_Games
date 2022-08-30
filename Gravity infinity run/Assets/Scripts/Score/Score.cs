using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	private Text score_text;

	public int player_score = 0;
	// Use this for initialization
	void Awake () 
	{
		score_text = GameObject.Find ("Score").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		score_text.text = player_score.ToString ();
	}
}