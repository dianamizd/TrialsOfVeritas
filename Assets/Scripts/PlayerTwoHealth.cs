using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoHealth : MonoBehaviour
{
    //since the 2nd players UI works in reverse, it's different from player 1's script

    //healthbar
    public Slider healthBar;

    //setting health variables - but will need to change for each different character
    //float maxHealth = 100;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //when the game starts, players health=0 (as it works in reverse)
        healthBar.value = 0;
        //health gets update when damage is taken
        currentHealth = healthBar.value;
    }

    //currently, when the player collides with the other player, they'll take damage(or in player 2's case, healed) - this can be changed when projectiles are implemeted
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthBar.value += 5f;
            currentHealth = healthBar.value;
        }

        //if (collision.gameObject.tag == "Projectile")
        //{
        //    healthBar.value -= 5f;
        //    currentHealth = healthBar.value;
        //}
    }
}
