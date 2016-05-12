using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public Image timer;

    Animator anim;
    float restartTimer;

    float timeLeft = 60f;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        if (playerHealth.isDead || timeLeft <= 0)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                playerHealth.RestartLevel();
            }
        }
    }
}
