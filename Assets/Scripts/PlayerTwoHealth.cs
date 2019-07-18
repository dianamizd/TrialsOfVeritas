using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoHealth : MonoBehaviour
{
    //since the 2nd players UI works in reverse, it's different from player 1's script

    //healthbar
    public Slider healthBar;

    //setting health variable
    public float currentHealth;

    //variable for respawn point
    public Transform respawnPoint;

    [SerializeField] private PlayerOneHealth playerOneScript;

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
            WhenNoHealthTwo();

            playerOneScript.WhenNoHealthOne();
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

    //method for when the player dies
    public void WhenNoHealthTwo()
    {
        gameObject.transform.position = respawnPoint.transform.position;

        healthBar.value = 0;
        currentHealth = healthBar.value;
    }
}
