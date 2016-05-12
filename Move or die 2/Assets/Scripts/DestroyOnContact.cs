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
		PlayerHealth playerHealth = other.GetComponent<PlayerHealth> ();
		if (playerHealth) {
			Debug.Log ("Player!");
			playerHealth.Death ();
			Destroy (gameObject);


		}

		 //This part is based on the tank tutorial

		/*Collider2D[] colliders =Physics2D.OverlapCircleAll(transform.position, explosionRadius);
		for (int i = 0; i < colliders.Length; i++)
		{
			Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();
			if (!targetRigidbody)
				continue;
			//PlayerHealth playerHealth = targetRigidbody.GetComponent<PlayerHealth>();
			if (!playerHealth)
				continue;
			Debug.Log ("dead");
		}*/
		explosion.transform.parent = null;

		explosion.Play();

		//explosionAudio.Play();

		Destroy (explosion.gameObject, explosion.duration);

		Destroy (gameObject);



	}
}

              







