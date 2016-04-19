using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D playerRigid;

	void Start () {
	
	}
	
	void FixedUpdate () {
		float movement = Input.GetAxis ("Horizontal");
		playerRigid = GetComponent<Rigidbody2D>();
		playerRigid.velocity = new Vector2 (movement * speed, playerRigid.velocity.y);

		//GetComponent<Rigidbody2D>().velocity = new Vector2 (movement * speed, rigidbody2D.velocity.y);

	}
}
