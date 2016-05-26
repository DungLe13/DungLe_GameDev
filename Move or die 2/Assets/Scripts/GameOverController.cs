using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameOverController : MonoBehaviour {

	public Text pigWin;
	public Text pigLose;
	public Text foxWin;
	public Text foxLose;

    // Use this for initialization
    void Start () {

    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Player Win") == 2)
        {
            pigLose.enabled = true;
            foxWin.enabled = true;
            pigWin.enabled = false;
            foxLose.enabled = false;
        }

        if (PlayerPrefs.GetInt("Player Win") == 1)
        {
            pigWin.enabled = true;
            foxLose.enabled = true;
            pigLose.enabled = false;
            foxWin.enabled = false;
        }
    }
	
}
