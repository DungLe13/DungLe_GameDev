using UnityEngine;
using System.Collections;

public class MoveOnContact : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		transform.Translate (Vector2.up);
	}
}