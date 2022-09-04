using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour {

	public Score MyScore;
	private Button jump_btn;
	private Score player_Score;
	private Rigidbody2D rb;
	private bool is_Up;
	private float force;

	void Awake ()
	{
		force = 4f;
		is_Up = false;
		rb = GetComponent<Rigidbody2D> ();
		jump_btn = GameObject.Find ("Jump button").GetComponent<Button> ();
		MyScore = GameObject.Find ("Players").GetComponent<Score> ();
	}

	void Start()
	{
		jump_btn.onClick.AddListener (() => Jump ());
	}

	void Jump()
	{
		Vector2 temp = rb.velocity;
		Vector3 Player_scale;
		if (is_Up == false)
		{
			temp.y = force;
			rb.velocity = temp;
			is_Up = true;
			Player_scale = transform.localScale;
			Player_scale.y = -0.7f;
			transform.localScale = Player_scale;

		}

		else if (is_Up == true)
		{
			temp.y = -force;
			rb.velocity = temp;
			is_Up = false;
			Player_scale = transform.localScale;
			Player_scale.y = 0.7f;
			transform.localScale = Player_scale;
		}

	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Coin") {
			MyScore.player_score++;
			Destroy (target.gameObject);
		} 
		else if (target.tag == "Bomb")
		{
			Destroy (target.gameObject);
			StartCoroutine (Game_Over ());
		}
	}

	IEnumerator Game_Over()
	{
		transform.position = new Vector3 (300.0f, 300.0f, 0.0f);
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Main_Menu");
	}
		
}
