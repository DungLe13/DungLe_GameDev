using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject bomb;

	void Start(){
		StartCoroutine (Spawn ());
	
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds (1.0f);
		while (true) {


			Vector3 spawnPosition = new Vector3 (Random.Range (-10.0F, 10.0F), transform.position.y+10.0f, 0.0f);
			Quaternion spawnRotation = Quaternion.identity; 
			Instantiate (bomb, spawnPosition, spawnRotation);

			yield return new WaitForSeconds (1.0f);
		}
	}
}
