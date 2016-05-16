using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public PlayerHealth player1Health;
    public PlayerHealth player2Health;
    public float restartDelay = 3f;
    //public Image timer;
    public Image pigWin;
    public Image foxWin;

    Animator anim;
    float restartTimer;

    float timeLeft = 60f;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        pigWin = GetComponent<Image>();
        foxWin = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        //timeLeft -= Time.deltaTime;

        if (player1Health.isDead)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            Color newFoxColor = foxWin.color;
            newFoxColor.a = 1;
            foxWin.color = newFoxColor;

            if (restartTimer >= restartDelay)
            {
                player1Health.RestartLevel();
            }
        }

        if (player2Health.isDead)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            Color newPigColor = pigWin.color;
            newPigColor.a = 1;
            foxWin.color = newPigColor;

            if (restartTimer >= restartDelay)
            {
                player2Health.RestartLevel();
            }
        }
    }
}
