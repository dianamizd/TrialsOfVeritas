using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Input : MonoBehaviour
{
    private float h;

    private float v;

    private Vector3 movementdirection = Vector3.zero;

    public int speed = 5;

    public float dodgespeed = 10;

    Rigidbody player_rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal_P1");

        v = Input.GetAxis("Vertical_P1");

        //movement input for player
        Vector3 movement = new Vector3(h, 0, v);

        if (Input.GetButtonDown("Horizontal_P1"))
        {
            print("player 1 left/right movement");
        } 

        if (Input.GetButtonDown("Vertical_P1"))
        {
            print("player 1 up/down movement");
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
        if(Input.GetButtonDown("Fire_P1"))
        {
            print("player 1 fire");
        }

        //dodging input for player
        if(Input.GetButtonDown("Dodge_P1"))
        {
            print("player 1 dodge");

            player_rigidbody.AddForce(transform.forward * dodgespeed);
        }
    }
}
