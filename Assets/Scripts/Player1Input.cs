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

    //current cooldown for dodge (if at zero input works)
    private float currentDodgeCooldownTime = 0.0f;

    //maximum cooldown time for dodge
    public float maxDodgeCooldownTime = 2.0f;

    //defining projectile
    public GameObject bullet;

    //speed of projectile
    public float bulletspeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
       
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
        transform.Translate(movement * Time.deltaTime * speed, Space.World);

        float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

        //makes player face direction of movement
        if ((movement.x != 0f) || (movement.y != 0f))
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
            instBulletRigidbody.AddForce(transform.forward * 500);

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
}
