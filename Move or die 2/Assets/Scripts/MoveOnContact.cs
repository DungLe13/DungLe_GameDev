using UnityEngine;
using System.Collections;

public class MoveOnContact : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D Player) {
		//float playerPosition = Player.rigidbody.position.y + 10f;
		//float bombPosition = transform.position.y;
		if (Player.gameObject.tag == "Player") {
			transform.position.y = Player.transform.position.y;
			Debug.Log ("i'm hurt");
		}

	}
}