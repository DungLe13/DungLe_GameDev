﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float speed = 10f;
	public float jumpHeight = 20f;
	public float previousY;
	private Rigidbody2D player1Rigid;
	bool letsJump;

	void Start ()
	{
	
	}

	void Update(){
		float currentY = GetComponent<Rigidbody2D> ().position.y;

		if (Mathf.Abs(currentY - previousY)<0.001) {
			letsJump = true;
			Debug.Log ("true");

		} else {
			letsJump = false;
			Debug.Log ("false");

		}
		if ((Input.GetKeyDown ("x"))&&(letsJump==true)) {
			player1Rigid.velocity = new Vector2 (player1Rigid.velocity.x, player1Rigid.position.y + jumpHeight);

		}
		previousY=currentY;

	
	}


	
	void FixedUpdate ()
	{
		

		float horizontal_movement = Input.GetAxis ("Horizontal");
		player1Rigid = GetComponent<Rigidbody2D> ();
		player1Rigid.velocity = new Vector2 (horizontal_movement * speed, player1Rigid.velocity.y);



	}

}
