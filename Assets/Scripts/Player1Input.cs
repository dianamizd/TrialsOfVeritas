using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Input : MonoBehaviour
{
    private float h;

    private float v;

    public int speed = 5;

    Vector3 movement;

    public GameObject bulletSpawn;

    //healthbar
    public Slider healthBar;

    public Text healthValue;

    //setting health variables - but will need to change for each different character
    public float maxHealth = 100;
    public float currentHealth;

    //current rounds claimed
    public int currentRoundCount;

    private int maxRoundCount = 3;

    //variable for the respawn point (empty game object)
    public Transform respawnPoint;

    //initialise script, to be able to pull references to it
    [SerializeField] private Player2Input playerTwoScript;

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

    //defining projectile
    public GameObject bullet;

    //speed of projectile
    public float bulletSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        giveMaxHealth();
    }

    // Update is called once per frame
    void Update()
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

        //movement input for player
        movement = new Vector3(h, 0, v);

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
        transform.Translate(movement * Time.deltaTime * speed, Space.World);

        float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

        //makes player face direction of movement
        if ((movement.x != 0f) || (movement.z != 0f))
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        Debug.Log(h);

        //attacking (firing) input for player
        if(Input.GetButtonDown("Fire_P1"))
        {
            print("player 1 fire");

            GameObject instBullet = Instantiate(bullet, bulletSpawn.transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * bulletSpeed);

            Object.Destroy(instBullet, 2.0f);
        }

        //dodging input for player
        if(Time.time > currentDodgeCooldownTime)
        {
            print("player 1 dodge ready");

            //playercharacter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            if (Input.GetButtonDown("Dodge_P1"))
            {
                print("player 1 dodge, now on cooldown");

                currentDodgeTime = 0.0f;
               
                //active cooldown for dodge
                currentDodgeCooldownTime = Time.time + maxDodgeCooldownTime;
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

        //resets health value
        giveMaxHealth();

    }

    private void giveMaxHealth()
    {
        //when the game starts, players health=max value
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;

        healthBar.value = maxHealth;

        //healthValue.text;
    }
}
