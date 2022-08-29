using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour {

	private Text scoreText;
	private int score = 0 ;

	void Start ()
	{
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
	}
	

	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Bomb") 
		{
			transform.position = new Vector2 (0, 100);
			Destroy (target.gameObject);
			StartCoroutine (RestartGame ());
		}
		if (target.tag == "Fruit")
		{
			print ("fruit");
			Destroy (target.gameObject);
			score++;
			scoreText.text = score.ToString ();
		}
	}

	IEnumerator RestartGame()
	{
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
