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

    //current rounds claimed
    public int currentRoundCount;

    public int maxRoundCount = 2;

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

            if (currentRoundCount <= maxRoundCount)
            {
                currentRoundCount += 1;
            }

            playerOneScript.WhenNoHealthOne();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //for damage from projectiles
        if (other.gameObject.tag == "Projectile")
        {
            healthBar.value += 5f;
            currentHealth = healthBar.value;

            Object.Destroy(other.gameObject);
        }

        //When the player enters the lava/water both players positions and health will be reset, with the round being updated.
        if (other.gameObject.tag == "Respawn")
        {
            WhenNoHealthTwo();

            if (currentRoundCount <= maxRoundCount)
            {
                currentRoundCount += 1;
            }

            playerOneScript.WhenNoHealthOne();
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
