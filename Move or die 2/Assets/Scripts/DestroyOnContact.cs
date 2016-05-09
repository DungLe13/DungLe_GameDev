using UnityEngine;
using System.Collections;

	public class DestroyOnContact : MonoBehaviour {
	public ParticleSystem explosion;
	public LayerMask playerMask;                        
	//public AudioSource explosionAudio;                
	public float damage = 100f;                    
	//public float m_ExplosionForce = 1000f;              
	//public float m_MaxLifeTime = 2f;                    
	public float explosionRadius = 5f;  
	void OnTriggerEnter2D(Collider2D other){
		/* This part is based on the tank tutorial
		Collider2D[] colliders =Physics2D.OverlapCircle(transform.position, explosionRadius, playerMask);
		for (int i = 0; i < colliders.Length; i++)
		{
			Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();
			if (!targetRigidbody)
				continue;
			PlayerHealth playerHealth = targetRigidbody.GetComponent<PlayerHealth>();
			if (!playerHealth)
				continue;

			playerHealth.Death();
		}
		explosion.transform.parent = null;

		explosion.Play();

		//explosionAudio.Play();

		Destroy (explosion.gameObject, explosion.duration);

		Destroy (gameObject);
		*/

			
		if (other.tag == "Player" || other.tag=="ground") {
			other.gameObject.GetComponent<PlayerHealth> ().Death ();
			Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
			Instantiate(explosion, transform.position,randomRotation);
			Destroy (gameObject);



		}
	}
}

              







