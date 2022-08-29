using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;
	private float force;
	private Button jump_Button;
	private GameObject parent;
	private GameObject camra;

	public delegate void OneStep ();
	public static event OneStep StepUp ;

	void InstantiateVariables () 
	{
		rb = GetComponent<Rigidbody2D> ();
		force = 10.0f;
		jump_Button = GameObject.Find ("Jump_Button").GetComponent<Button> ();
		camra = GameObject.Find ("Main Camera");

	}

	void Awake()
	{
		InstantiateVariables ();
	}
	void Start () 
	{
		
		jump_Button.onClick.AddListener (Player_Jump);
	}

	public void Player_Jump()
	{
		if (rb.velocity.y == 0.0f) 
		{
			Vector2 temp = rb.velocity;
			temp.y = force;
			rb.velocity = temp;
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		
		if (coll.gameObject.tag == "Platform" && (rb.velocity.y > -0.1 && rb.velocity.y < 0.1f))
		{
			parent = coll.gameObject;
			transform.SetParent (parent.transform);

			if (camra.transform.position.y < transform.parent.position.y + 4.1f && (rb.velocity.y > -0.1 && rb.velocity.y < 0.1f))
			{
				print ("goUp");
				StepUp ();
			}

		}
	}

	private void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Platform")
		{
			parent = coll.gameObject;
			transform.SetParent (null);
		}
	}
}
