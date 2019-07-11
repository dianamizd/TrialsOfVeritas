using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Input : MonoBehaviour
{
    private float h;

    private float v;

    public int speed = 5;

    public int dodgespeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement for player
        Vector3 movement = new Vector3(h, 0, v);

        if (Input.GetButtonDown("Horizontal_P2"))
        {
            print("player 2 left/right movement");
        }

        if (Input.GetButtonDown("Vertical_P2"))
        {
            print("player 2 up/down movement");
        }

        h = Input.GetAxis("Horizontal_P2");

        v = Input.GetAxis("Vertical_P2");

        //moves player
        transform.Translate(movement * Time.deltaTime * speed, 0);

        //makes player face direction of movement
        if ((movement.x != 0) || (movement.y != 0))
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        Debug.Log(h);
        
        //attacking (firing) input for player
        if (Input.GetButtonDown("Fire_P2"))
        {
            print("player 2 fire");
        }

        //dodging input for player
        if (Input.GetButtonDown("Dodge_P2"))
        {
            print("player 2 dodge");

            if (speed == 7)
            {
                speed += dodgespeed;

                if (speed > 7)
                {
                    speed = 7;
                }
            }

            
            
        }
    }
}
