using UnityEngine;
using System.Collections;

public class MoveOnContact : MonoBehaviour {

    public static GameObject bombTransform;
    public GameObject playerTransform;
    Vector2 bombPosition = bombTransform.transform.position;

    void OnCollisionEnter2D(Collision2D Player) {
		//float playerPosition = Player.rigidbody.position.y + 10f;
		//float bombPosition = transform.position.y;
		if (Player.gameObject.tag == "Player") {
            bombPosition.x = playerTransform.transform.position.x;
            bombPosition.y = playerTransform.transform.position.y + 1;
            Debug.Log ("i'm hurt");
		}

	}
}