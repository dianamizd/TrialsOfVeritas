using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Input : MonoBehaviour
{
    private float h;

    private float v;

    public int speed = 5;

    Vector3 movement;

    //speed of dodge
    public float dodgeSpeed = 1.0f;

    //distance which the dodge pushes the player
    public float dodgeDistance = 5;

    //indicates direction dodge will go
    public Vector3 dodgeDirection;

    //speed which the dodge stops
    private float dodgeStopSpeed = 0.1f;

    //the maximum time of dodging
    private const float maxdodgeTime = 1.0f;

    //current time which dodge is active
    float currentdodgeTime = maxdodgeTime;

    public GameObject bullet;

    public float bulletspeed = 100f;

    CharacterController controller;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<CharacterController>();
    }

    private void Start()
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

            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(Vector3.forward * bulletspeed);
        }

        //dodging input for player
        if(Input.GetButtonDown("Dodge_P1"))
        {
            print("player 1 dodge");

            currentdodgeTime = 0.0f;
        }

        if (currentdodgeTime < maxdodgeTime)
        {
            movement = transform.forward * dodgeDistance;
            
            currentdodgeTime += dodgeStopSpeed;
        }
        else
        {
           movement = Vector3.zero;
        }
        controller.Move(movement * Time.deltaTime * dodgeSpeed);
    }
}
