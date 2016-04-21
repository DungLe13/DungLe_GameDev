using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;
	public float jumpHeight=20f;
	private Rigidbody2D player1Rigid;
	void Start () {
	
	}

	void Update(){
		if (Input.GetKeyDown ("space")) {
			player1Rigid.velocity = new Vector2 (player1Rigid.velocity.x, player1Rigid.position.y+jumpHeight);

		}
		
	
	
	
	}

	
	void FixedUpdate () {
		float horizontal_movement = Input.GetAxis ("Horizontal");
		//float vertical_movement = Input.GetAxis ("Jump");
		player1Rigid = GetComponent<Rigidbody2D>();
		player1Rigid.velocity = new Vector2 (horizontal_movement * speed, player1Rigid.velocity.y);
		//player1Rigid.velocity = new Vector2 (player1Rigid.velocity.x, vertical_movement * speed);


	}
}
