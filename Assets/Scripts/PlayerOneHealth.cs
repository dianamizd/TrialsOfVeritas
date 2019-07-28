﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneHealth : MonoBehaviour
{
    //healthbar
    public Slider healthBar;

    //setting health variables - but will need to change for each different character
    public float maxHealth = 100;
    public float currentHealth;

    //current rounds claimed
    public int currentRoundCount;

    private int maxRoundCount = 3;

    //variable for the respawn point (empty game object)
    public Transform respawnPoint;

    //initialise script, to be able to pull references to it
    [SerializeField] private PlayerTwoHealth playerTwoScript;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
        //when the game starts, players health=max value
        healthBar.value = currentHealth/maxHealth;

      
    }

    private void Update()
    {
        //when health = 0, the character will respawn, health for the player goes back up, and restart the positions of the other player
        if (currentHealth == 0f)
        {
            WhenNoHealthOne();

            if (currentRoundCount < maxRoundCount)
            {
                currentRoundCount += 1;
            }

            playerTwoScript.WhenNoHealthTwo();
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        //for damage from projectiles
        if (other.gameObject.tag == "Projectile")
        {
            healthBar.value -= 5f;
            //health gets update when damage is taken
            currentHealth = healthBar.value;

            Object.Destroy(other.gameObject);
        }

        //player health increase upon picking up power-up
        if (other.CompareTag("Power-Up"))
        {
            healthBar.value += 10f;
            currentHealth = healthBar.value;
        }
    }

    //method for when the player dies
    public void WhenNoHealthOne()
    {
        gameObject.transform.position = respawnPoint.transform.position;

        healthBar.value = maxHealth/currentHealth;
        currentHealth = healthBar.value;

    }
}
