﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Input : MonoBehaviour
{
    private float h;

    private float v;

    //player movement speed
    public int movementSpeed = 10;

    private Vector3 movement;

    public GameObject bulletSpawn;

    //healthbar
    public Slider healthBar;

    //display health value in UI
    public Text healthValue;

    //display round count in UI
    public Text roundCount;

    //display name of chosen class
    public Text Name;

    //setting health variable
    public float maxHealth = 100;
    public float currentHealth;

    //current rounds claimed
    public int currentRoundCount;

    public int maxRoundCount = 2;

    //variable for respawn point
    public Transform respawnPoint;

    [SerializeField] private Player1Input playerOneScript;

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

    public GameObject playercharacter;

    // Start is called before the first frame update
    void Start()
    {
        giveMaxHealth();

        className();

        currentRoundCount = 0;

        roundCount.text = currentRoundCount + "";
    }

    // Update is called once per frame
    void Update()
    {
        //when the character's health = 0 (which is 100), the character will reset both their position and health
        if (currentHealth == 0f)
        {
            WhenNoHealthTwo();

            addRound();

            playerOneScript.WhenNoHealthOne();
        }

        //movement for player
        movement = new Vector3(h, 0, v);

        h = Input.GetAxis("Horizontal_P2");

        v = Input.GetAxis("Vertical_P2");

        if (Input.GetButtonDown("Horizontal_P2"))
        {
            print("player 2 left/right movement");
        }

        if (Input.GetButtonDown("Vertical_P2"))
        {
            print("player 2 up/down movement");
        }

        //moves player
        transform.Translate(movement * Time.deltaTime * movementSpeed, 0);

        //makes player face direction of movement
        if((movement.x != 0) || (movement.y != 0)) 
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
        

        Debug.Log(h);
        
        //attacking (firing) input for player
        if (Input.GetButtonDown("Fire_P2"))
        {
            print("player 2 fire");

            GameObject instBullet = Instantiate(bullet, bulletSpawn.transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * bulletSpeed);

            Object.Destroy(instBullet, 2.0f);
        }

        //dodging input for player
        if (Time.time > currentDodgeCooldownTime)
        {
            print("player 2 dodge ready");

            //playercharacter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            if (Input.GetButtonDown("Dodge_P2"))
            {
                print("player 2 dodge, now on cooldown");

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
           
            //active dodge time
            currentDodgeTime += dodgeStopSpeed;

            //dodge state indicator
            //playercharacter.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        }
        else
        {
            movement = Vector3.zero;
        }
    }

    //for damage from projectiles
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            healthBar.value -= 5f;
            currentHealth = healthBar.value;

            healthValue.text = currentHealth + "/" + maxHealth;

            Object.Destroy(other.gameObject);
        }
    }

    //method for when the player dies
    public void WhenNoHealthTwo()
    {
        gameObject.transform.position = respawnPoint.transform.position;

        //resets health value
        giveMaxHealth();

        
    }

    private void className()
    {
        Name.text = "Default";
    }

    private void giveMaxHealth()
    {
        //when the game starts, players health=max value
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;

        healthBar.value = maxHealth;

        healthValue.text = currentHealth + "/" + maxHealth;
    }

    private void addRound()
    {
        //if (currentRoundCount <= maxRoundCount)
        //{
            //currentRoundCount += 1;
        //}

        if(currentRoundCount == maxRoundCount)
        {
            Application.Quit();
        }

        else
        {
            currentRoundCount += 1;
        }
    }
}
