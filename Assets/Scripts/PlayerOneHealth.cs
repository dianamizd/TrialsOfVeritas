using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneHealth : MonoBehaviour
{
    //healthbar
    [SerializeField] private Slider healthBar;

    //setting health variables - but will need to change for each different character
    private float maxHealth = 100;
    private float currentHealth;

    //variable for the respawn point (empty game object)
    [SerializeField] private Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //when the game starts, players health=max value
        healthBar.value = maxHealth;
        //health gets update when damage is taken
        currentHealth = healthBar.value;
    }

    private void Update()
    {
        //when health = 0, the character will respawn, health for the player goes back up
        if (currentHealth == 0f)
        {
            gameObject.transform.position = respawnPoint.transform.position;

            healthBar.value = 100;
            currentHealth = healthBar.value;

            //update the round? (or maybe in another script)
            //also respawn other player and reset their health
        }
    }

    //currently, when the player collides with the other player, they'll take damage - this can be changed when projectiles are implemeted
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            healthBar.value -= 5f;
            currentHealth = healthBar.value;
        }
    }

   
    private void OnTriggerEnter(Collider other)
    { 
        //for damage from projectiles
        if (other.gameObject.tag == "Projectile")
        {
            healthBar.value -= 5f;
            currentHealth = healthBar.value;
        }

        //player health increase upon picking up power-up
        if (other.CompareTag("Power-Up"))
        {
            healthBar.value += 10f;
            currentHealth = healthBar.value;
        }
    }

    
    


}
