using UnityEngine;
using System.Collections;

public class MoveOnContact : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D Player) {
		//float playerPosition = Player.rigidbody.position.y;
		//float bombPosition = transform.position.y;
		if (Player.gameObject.tag == "Player") {
			
			//bombPosition = playerPosition + 10.0f;
			Debug.Log ("i'm hurt");
		}

	}
}