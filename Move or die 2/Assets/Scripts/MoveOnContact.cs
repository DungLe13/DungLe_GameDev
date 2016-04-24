using UnityEngine;
using System.Collections;

public class MoveOnContact : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		transform.position = other.transform.position;
	}
}