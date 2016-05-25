using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float speed = 10f;
	public float jumpHeight = 20f;
	float previousY;
	float previousX;

	private Rigidbody2D player1Rigid;
	bool letsJump;
	Animator anim;
	bool loaded;
	public Rigidbody2D explosiveBomb;
	public Transform bombPosition;
	public float throwForce;

    string jumpButton;
	string throwButton;
	float launchSpeed;
	bool isThrown;

    public string playerNumber;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		throwButton = "Fire" + playerNumber;
        jumpButton = "Jump" + playerNumber;
	}

	void Update ()
	{
		float currentY = GetComponent<Rigidbody2D> ().position.y;
		float currentX = GetComponent<Rigidbody2D> ().position.x;

		if (Mathf.Abs (currentY - previousY) < 0.001) {
			letsJump = true;

		} else {
			letsJump = false;

		}
		if ((Input.GetButtonDown (jumpButton)) && (letsJump == true)) {
			player1Rigid.velocity = new Vector2 (player1Rigid.velocity.x, player1Rigid.position.y + jumpHeight);

		}
		previousY = currentY;

		if (currentX < previousX) {
			if (Input.GetButtonDown (throwButton) && (loaded == true)) {
				Throw (right: false);
			}

		} else {
			if (Input.GetButtonDown (throwButton) && (loaded == true)) {
				Throw (right: true);
			}
		}
		previousX = currentX;


	}

	void FixedUpdate ()
	{
		float horizontal_movement = Input.GetAxis ("Horizontal" + playerNumber);
		player1Rigid = GetComponent<Rigidbody2D> ();
		player1Rigid.velocity = new Vector2 (horizontal_movement * speed, player1Rigid.velocity.y);

	}

	void OnCollisionEnter2D (Collision2D other)
	{

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

		} else  {
			bombInstace.velocity = throwForce * bombPosition.right * -1;


		}


		loaded = false;
		anim.SetBool ("HaveBomb", false);
	}
}
