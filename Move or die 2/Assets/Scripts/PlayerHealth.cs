using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
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
            currentHealth -= 1;
            content.fillAmount = currentHealth;
        } else
        {
            damaged = false;
            currentHealth += 30;
            content.fillAmount = currentHealth;

            if (currentHealth >= 100)
            {
                currentHealth = 100;
            }
        }

        previousPosition = currentPosition;

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
}
