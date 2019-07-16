using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Input : MonoBehaviour
{
    private float h;

    private float v;

    public int speed = 5;

    Vector3 movement;

    public GameObject bulletSpawn;


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

    public float currentDodgeCooldownTime = 10.0f;

    private float maxDodgeCooldownTime = 10.0f;

    private bool dodgeActive = true;

    //defining projectile
    public GameObject bullet;

    //speed of projectile
    public float bulletspeed = 100f;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        dodgeActive = Input.GetButtonDown("Dodge_P1");

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.Translate(movement * Time.deltaTime * speed, 0);

        //makes player face direction of movement
        if ((movement.x != 0) || (movement.y != 0))
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        Debug.Log(h);

        //attacking (firing) input for player
        if(Input.GetButtonDown("Fire_P1"))
        {
            print("player 1 fire");

            GameObject instBullet = Instantiate(bullet, bulletSpawn.transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * 500);
        }

        //dodging input for player
        if(Input.GetButtonDown("Dodge_P1"))
        {
            print("player 1 dodge");

            currentDodgeTime = 0.0f;
            currentDodgeCooldownTime = 0.0f;
        } 
        //during dodge period
        if (currentDodgeTime < maxDodgeTime)
        {
            movement = transform.forward * dodgeDistance;
            transform.Translate(movement * Time.deltaTime * dodgeSpeed, 0);
            currentDodgeTime += dodgeStopSpeed;
            dodgeActive = false;
        }
        else
        {
            movement = Vector3.zero;
        }

        if(currentDodgeCooldownTime < maxDodgeCooldownTime)
        {
            print("dodge on cooldown");
            currentDodgeCooldownTime += dodgeStopSpeed;
            dodgeActive = false;
        }
        else
        {
            print("dodge ready");
            dodgeActive = true;
        }
    }
}
