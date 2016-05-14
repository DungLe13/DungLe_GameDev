using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float speed = 10f;
	public float jumpHeight = 20f;
	public float previousY;
	private Rigidbody2D player1Rigid;
	bool letsJump;
	Animator anim;
	bool loaded;
	public Rigidbody2D explosiveBomb;
	public Transform bombPosition;
	public float throwForce;

	string throwButton;
	float launchSpeed;
	bool isThrown;


	void Start ()
	{
		anim = GetComponent<Animator> ();
		throwButton = "space";
	}

	void Update ()
	{
		float currentY = GetComponent<Rigidbody2D> ().position.y;

		if (Mathf.Abs (currentY - previousY) < 0.001) {
			letsJump = true;

		} else {
			letsJump = false;
			//anim.SetBool("HaveBomb", false);

		}
		if ((Input.GetKeyDown ("up")) && (letsJump == true)) {
			player1Rigid.velocity = new Vector2 (player1Rigid.velocity.x, player1Rigid.position.y + jumpHeight);

		}
		previousY = currentY;

		//need to figure out how to change the bomb throwing direction
		if (Input.GetKeyDown ("space") && (loaded == true)) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				Throw (right: false);
			} else {
				Throw (right: true);

			}
		}
	}

	void FixedUpdate ()
	{
		float horizontal_movement = Input.GetAxis ("Horizontal");
		player1Rigid = GetComponent<Rigidbody2D> ();
		player1Rigid.velocity = new Vector2 (horizontal_movement * speed, player1Rigid.velocity.y);

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		//Debug.Log ("hey");

		if ((other.gameObject.tag == "Bomb") && (loaded == false)) {
			anim.SetBool ("HaveBomb", true);
			Destroy (other.gameObject);
			loaded = true;
		
		}

	}

	private void Throw (bool right)
	{
		isThrown = true;
		Rigidbody2D bombInstace = Instantiate (explosiveBomb, bombPosition.position, bombPosition.rotation) as Rigidbody2D;
		/*
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			bombInstace.velocity = throwForce * bombPosition.right * -1;
			Debug.Log (bombInstace.velocity);

		}else{
		bombInstace.velocity = throwForce * bombPosition.right;
		}
		*/
		if (right == true) {
			bombInstace.velocity = throwForce * bombPosition.right;
			Debug.Log ("right");
		} else  {
			bombInstace.velocity = throwForce * bombPosition.right * -1;
			Debug.Log ("left");

		}


		loaded = false;
		anim.SetBool ("HaveBomb", false);
	}
}
