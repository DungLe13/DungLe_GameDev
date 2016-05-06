using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public float startingHealth = 1;
    public float currentHealth;
    public Vector2 previousPosition;
    Vector2 currentPosition;
    
    public Image content;

    PlayerMovement playerMovement;
    bool isDead;
    bool damaged;

    void Awake()
    {
        playerMovement = GetComponent <PlayerMovement> ();
  
        currentHealth = startingHealth;
    }

    void Update()
    {
        //damaged = false;
        currentPosition = GetComponent<Rigidbody2D>().position;
        
        TakeDamage();
    }

    public void TakeDamage()
    {
        // By not moving
        if (currentPosition == previousPosition)
        {
            damaged = true;
            currentHealth -= 0.01f;
            content.fillAmount = currentHealth;
        } else
        {
            damaged = false;
            currentHealth += 0.03f;
            content.fillAmount = currentHealth;

            if (currentHealth >= 1)
            {
                currentHealth = 1;
            }
        }

        previousPosition = currentPosition;

        // By falling down
        if (currentPosition.y <= -14)
        {
            currentHealth = 0;
        }

        // By being hit by bombs

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Destroy(this.gameObject);
        playerMovement.enabled = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
