using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public PlayerHealth player1Health;
    public PlayerHealth player2Health;

	public  Text pigWin;
	public Text pigLose;
	public Text foxWin;
	public Text foxLose;

    // Use this for initialization
    void Start () {
        pigWin = GetComponent<Text>();
        pigLose = GetComponent<Text>();
        foxWin = GetComponent<Text>();
        foxLose = GetComponent<Text>();

        pigWin.enabled = false;
        pigLose.enabled = false;
        foxWin.enabled = false;
        foxLose.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (player1Health.isDead)
        {
            pigLose.enabled = true;
            foxWin.enabled = true;
        }

        if (player2Health.isDead)
        {
            pigWin.enabled = true;
            foxLose.enabled = true;
        }
    }
}
