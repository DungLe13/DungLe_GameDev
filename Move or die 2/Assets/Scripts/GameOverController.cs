using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public PlayerHealth player1Health;
    public PlayerHealth player2Health;
    public float restartDelay = 3f;
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
        //timeLeft -= Time.deltaTime;

        if (player1Health.isDead)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                player1Health.RestartLevel();
            }
        }

        if (player2Health.isDead)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                player2Health.RestartLevel();
            }
        }
    }
}
