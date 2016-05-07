using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject bomb;

    [HideInInspector] public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public Image timer;

    Animator anim;
    float restartTimer;

    float timeLeft = 60f;

    void Awake()
    {
        anim = GetComponent <Animator>();
    }

	void Start(){
		StartCoroutine (Spawn ());
	
	}

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (playerHealth.currentHealth <= 0 || timeLeft <= 0)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                playerHealth.RestartLevel();
            }
        }
    }

	IEnumerator Spawn(){
		yield return new WaitForSeconds (1.0f);
		while (true) {


			Vector3 spawnPosition = new Vector3 (Random.Range (-10.0F, 10.0F), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity; 
			Instantiate (bomb, spawnPosition, spawnRotation);

			yield return new WaitForSeconds (2.0f);
		}
	}
}
