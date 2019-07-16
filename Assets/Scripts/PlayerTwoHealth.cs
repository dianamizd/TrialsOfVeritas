using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoHealth : MonoBehaviour
{
    //since the 2nd players UI works in reverse, it's different from player 1's script

    //healthbar
    [SerializeField] private Slider healthBar;

    //setting health variable
    public float currentHealth;

    //variable for respawn point
    [SerializeField] private Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //when the game starts, players health=0 (as it works in reverse)
        healthBar.value = 0;
        //health gets update when damage is taken
        currentHealth = healthBar.value;
    }

    private void Update()
    {
        //when the character's health = 0 (which is 100), the character will reset both their position and health
        if (currentHealth == 100f)
        {
            gameObject.transform.position = respawnPoint.transform.position;

            healthBar.value = 0;
            currentHealth = healthBar.value;

            //also respawn other character and reset their health.
        }
    }

    //currently, when the player collides with the other player, they'll take damage(or in player 2's case, healed) - this can be changed when projectiles are implemeted
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthBar.value += 5f;
            currentHealth = healthBar.value;
        }
    }

    //for damage from projectiles
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            healthBar.value += 5f;
            currentHealth = healthBar.value;
        }
    }
}
