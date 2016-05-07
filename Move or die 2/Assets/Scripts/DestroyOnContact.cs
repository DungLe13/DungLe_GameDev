using UnityEngine;
using System.Collections;

	public class DestroyOnContact : MonoBehaviour {
	public ParticleSystem explosion;
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealth> ().Death ();
			Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
			Instantiate(explosion, transform.position,randomRotation);
			Destroy (gameObject);



		}
	}
}