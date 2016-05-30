using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject bomb;
    public GameObject player1RB;
    public GameObject player2RB;

	void Start(){
		StartCoroutine (Spawn ());

        player1RB = GameObject.Find("character_1");
        player2RB = GameObject.Find("character_2");
	}

    void Update()
    {
        if (player1RB == null)
        {
            Debug.Log("PLayer 2 wins");
            PlayerPrefs.SetInt("Player Win", 2);
            SceneManager.LoadScene(2);
        }

        if (player2RB == null)
        {
            Debug.Log("Player 1 wins");
            PlayerPrefs.SetInt("Player Win", 1);
            SceneManager.LoadScene(2);
        }
    }

	IEnumerator Spawn(){
		yield return new WaitForSeconds (0.5f);
		while (true) {


			Vector3 spawnPosition = new Vector3 (Random.Range (-10.0F, 10.0F), transform.position.y+10.0f, 0.0f);
			Quaternion spawnRotation = Quaternion.identity; 
			Instantiate (bomb, spawnPosition, spawnRotation);

			yield return new WaitForSeconds (2.0f);
		}
	}
}
