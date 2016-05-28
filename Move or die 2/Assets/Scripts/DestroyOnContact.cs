using UnityEngine;
using System.Collections;

	public class DestroyOnContact : MonoBehaviour {
	public ParticleSystem explosion;
	public LayerMask playerMask;                        
	public AudioSource explosionAudio;                

	void OnTriggerEnter2D(Collider2D other){
		PlayerHealth playerHealth = other.GetComponent<PlayerHealth> ();

		if (playerHealth) {
			Debug.Log ("Player!");
			playerHealth.Death ();
			Destroy (gameObject);
			}
		GameObject player= GameObject.FindGameObjectWithTag ("Player");

		Rigidbody2D rg = player.GetComponent<Rigidbody2D> ();
		Vector2 bombToplayer = player.transform.position - transform.position;
		Vector2 maxDist= new Vector2 (100,100);
		if (bombToplayer.magnitude < 4) {
			rg.AddForce ((maxDist- bombToplayer) * 8, ForceMode2D.Force);
		}


		if (playerHealth) {
			playerHealth.Death ();
			Destroy (gameObject);
		}
		explosion.transform.parent = null;
		explosion.Play();
		Destroy (explosion.gameObject, explosion.duration);
		Destroy (gameObject);
	}
}

              







