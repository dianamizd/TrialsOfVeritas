using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Input : MonoBehaviour
{
    private float h;

    private float v;

    public int speed = 5;

    public Vector3 movement;

    //speed of dodge
    public float dodgeSpeed = 1.0f;

    //distance which the dodge pushes the player
    public float dodgeDistance = 5;

    //current time which dodge is active
    public float currentdodgeTime = 1.0f;

    //speed which the dodge stops
    private float dodgeStopSpeed = 0.1f;

    //the maximum time of dodging
    private float maxdodgeTime;

    public GameObject bullet;

    public float bulletspeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
       currentdodgeTime  = maxdodgeTime;
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.Translate(movement * Time.deltaTime * speed, 0);

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

            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(Vector3.forward * bulletspeed);
        }

        //dodging input for player
        if (Input.GetButtonDown("Dodge_P2"))
        {
            print("player 2 dodge");

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

    }
}
