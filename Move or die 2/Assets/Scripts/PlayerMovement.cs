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

	void Update(){
		float currentY = GetComponent<Rigidbody2D> ().position.y;

		if (Mathf.Abs(currentY - previousY)<0.001) {
			letsJump = true;

		} else {
			letsJump = false;
			//anim.SetBool("HaveBomb", false);

		}
		if ((Input.GetKeyDown ("up"))&&(letsJump==true)) {
			player1Rigid.velocity = new Vector2 (player1Rigid.velocity.x, player1Rigid.position.y + jumpHeight);

		}
		previousY=currentY;

		if(Input.GetKeyDown("space")&&(loaded==true)){

			Throw();
		}

	}
		
	void FixedUpdate ()
	{
		float horizontal_movement = Input.GetAxis ("Horizontal");
		player1Rigid = GetComponent<Rigidbody2D> ();
		player1Rigid.velocity = new Vector2 (horizontal_movement * speed, player1Rigid.velocity.y);

	}

	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log ("hey");

		if ((other.gameObject.tag == "Bomb")&& (loaded==false)) {
			anim.SetBool ("HaveBomb", true);
			Debug.Log ("hey");
			Destroy (other.gameObject);
			loaded = true;
		}

	}

	private void Throw(){
		isThrown = true;
		Rigidbody2D bombInstace = Instantiate (explosiveBomb, bombPosition.position, bombPosition.rotation) as Rigidbody2D;
		bombInstace.velocity = throwForce * bombPosition.forward;
	
	}
}
