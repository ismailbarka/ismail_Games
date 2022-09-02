using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_score : MonoBehaviour {

	private Text score_text;
	[HideInInspector] public int score = 0;

	void Awake () 
	{
		score_text = GetComponent<Text> ();
	}
	

	void Update ()
	{
		score_text.text = ("score : " + score.ToString());	
	}
}
