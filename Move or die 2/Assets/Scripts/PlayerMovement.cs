﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float speed = 10f;
	public float jumpHeight = 20f;
	float previousY;
	private Rigidbody2D player1Rigid;
	bool letsJump;

	void Start ()
	{
	
	}




	
	void FixedUpdate ()
	{
		float currentY = GetComponent<Rigidbody2D> ().position.y;
		if (currentY != previousY) {
			letsJump = false;
			Debug.Log ("false");

		} else {
			letsJump = true;
			Debug.Log ("true");

		}

		previousY=currentY;
		float horizontal_movement = Input.GetAxis ("Horizontal");
		player1Rigid = GetComponent<Rigidbody2D> ();
		player1Rigid.velocity = new Vector2 (horizontal_movement * speed, player1Rigid.velocity.y);

		if ((Input.GetKeyDown ("space"))&&(letsJump==true)) {
			player1Rigid.velocity = new Vector2 (player1Rigid.velocity.x, player1Rigid.position.y + jumpHeight);

		}

	}
}
