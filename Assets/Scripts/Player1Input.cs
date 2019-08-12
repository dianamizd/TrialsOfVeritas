using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Input : MonoBehaviour
{
    private float h;

    private float v;

    //player movement speed
    public int movementSpeed = 10;

    private Vector3 lookDirection;

    private float lookSpeed = 1000f;

    Vector3 movement;

    //emit bullets
    public GameObject bulletSpawn;

    //healthbar
    public Slider healthBar;

    //display health value in UI text
    public Text healthValue;

    //display round count in UI text
    public Text roundCount;

    //display name of chosen class
    public string Name;

    public string classType;

    public Text characterName;

    //setting health variables
    public float maxHealth = 100;
    public float currentHealth;

    //current rounds claimed
    public int currentRoundCount;

    public int maxRoundCount = 2;

    //variable for the respawn point (empty game object)
    public Transform respawnPoint;

    //initialise script, to be able to pull references to it
    [SerializeField] private Player2Input playerTwoScript;
    [SerializeField] private ScoreCheck scoreCheck;

    //speed of dodge
    public float dodgeSpeed = 1.0f;

    //distance which the dodge pushes the player
    public float dodgeDistance = 5;

    //current time which dodge is active
    public float currentDodgeTime = 1.0f;

    //speed which the dodge stops
    private float dodgeStopSpeed = 0.1f;

    //the maximum time of dodging
    private float maxDodgeTime = 1.0f;

    //current cooldown for dodge (if at zero input works)
    private float currentDodgeCooldownTime = 0.0f;

    //maximum cooldown time for dodge
    public float maxDodgeCooldownTime = 2.0f;

    private bool invincibleState = false;

    private float currentInvincibleTime = 0.0f;

    public float maxInvincibleTime = 1.0f;

    //defining projectile
    public GameObject bullet;

    //speed of projectile
    public float bulletSpeed = 100f;

    public float bulletDamage = 10f;

    private float currentBulletCooldownTime = 0.0f;

    public float maxBulletCooldownTime = 1.0f;

    public GameObject playerCharacter;

    public Rigidbody rigidbod;

    // Start is called before the first frame update
    void Start()
    {
        giveMaxHealth();

        className();

        //newName = GetComponent<Text>();

        currentRoundCount = 0;

        roundCount.text = currentRoundCount + "";
    }

    // Update is called once per frame
    void Update()
    {
        //when health = 0, the character will respawn, health for the player goes back up, and restart the positions of the other player
        if (currentHealth == 0f)
        {
            WhenNoHealthOne();

            playerTwoScript.addRound();

            playerTwoScript.WhenNoHealthTwo();

            scoreCheck.countdownTimer = 4;

            scoreCheck.CountdownTimer();
        }

        if(invincibleState == true)
        {
            if(Time.time > currentInvincibleTime)
            {
                print("player 2 invincible");

                currentInvincibleTime = Time.time + maxInvincibleTime;

                //playerCharacter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

                invincibleState = false;
            }
        }

        //movement input for player
        movement = new Vector3(h, 0, v);

        lookDirection = new Vector3(h, 0, v);

        if (Input.GetButtonDown("Horizontal_P1"))
        {
            print("player 1 left/right movement");
        } 

        if (Input.GetButtonDown("Vertical_P1"))
        {
            print("player 1 up/down movement");
        }

        h = Input.GetAxis("Horizontal_P1");

        v = Input.GetAxis("Vertical_P1");

        //moves player
        transform.Translate(movement * Time.deltaTime * movementSpeed, Space.World);

        //makes player face direction of movement
        if ((movement.x != 0f) || (movement.z != 0f))
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }


        Debug.Log(h);

        //attacking (firing) input for player
        if(Time.time > currentBulletCooldownTime)
        {
            print("player 1 shoot ready");

            if (Input.GetButtonDown("Fire_P1"))
            {
                print("player 1 fire");

                GameObject instBullet = Instantiate(bullet, bulletSpawn.transform.position, transform.rotation) as GameObject;
                Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                instBulletRigidbody.AddForce(transform.forward * bulletSpeed);

                currentBulletCooldownTime = Time.time + maxBulletCooldownTime;

                Object.Destroy(instBullet, 2.0f);
            }
        }

        

        //dodging input for player
        if(Time.time > currentDodgeCooldownTime)
        {
            print("player 1 dodge ready");

            

            if (Input.GetButtonDown("Dodge_P1"))
            {
                if(!invincibleState)
                {
                   print("player 1 dodge, now on cooldown");

                   currentDodgeTime = 0.0f;

                   //active cooldown for dodge
                   currentDodgeCooldownTime -= Time.time;

                   invincibleState = true;
                }
                    
            }  
        }

        //during dodge period
        if (currentDodgeTime < maxDodgeTime)
        {
            movement = transform.forward * dodgeDistance;
            transform.Translate(movement * Time.deltaTime * dodgeSpeed, 0);
            currentDodgeTime += dodgeStopSpeed;

            //dodge state indicator
            //playercharacter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
        else
        {
            movement = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!invincibleState)
        {
            //for damage from projectiles
            if (other.gameObject.tag == "Projectile")
            {
                playerDamage();

                Object.Destroy(other.gameObject);
            }
        }
       
        //player health increase upon picking up power-up
        if (other.CompareTag("Power-Up"))
        {
            healthBar.value += 10f;
            currentHealth = healthBar.value;
        }

        //when the player goes into the lava/water, both charcters will respawn with the round counter updating.
        if (other.gameObject.tag == "Respawn")
        {
            WhenNoHealthOne();

            playerTwoScript.addRound();

            playerTwoScript.WhenNoHealthTwo();
        }
    }

    //method for when the player dies
    public void WhenNoHealthOne()
    {
        gameObject.transform.position = respawnPoint.transform.position;

        //resets health value
        giveMaxHealth();

        bulletDamage = playerTwoScript.bulletDamage;

    }

    //method to specify current class
    private void className()
    {
        characterName.text = "" + Name; 
    }

    //method that gives player max health upon start or round reset
    private void giveMaxHealth()
    {
        //when the game starts, players health=max value
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;

        healthBar.value = maxHealth;

        healthValue.text = currentHealth + "/" + maxHealth; 
    }

    //method that gives player round point upon win
    public void addRound()
    {
        if(currentRoundCount < maxRoundCount)
        {
            currentRoundCount += 1;

            roundCount.text = currentRoundCount + "";
        }
    }

    public void playerDamage()
    {
        healthBar.value -= playerTwoScript.bulletDamage;

        //health gets update when damage is taken
        currentHealth = healthBar.value;
        healthValue.text = currentHealth + "/" + maxHealth;
    }
}
