using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Input : MonoBehaviour
{
    private float h;

    private float v;

    public int speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        h = Input.GetAxis("Horizontal_P1");

        v = Input.GetAxis("Vertical_P1");

        //moves player
        transform.Translate(movement * Time.deltaTime * speed, 0);

        //makes player face direction of movement
        transform.rotation = Quaternion.LookRotation(movement);

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
        }
    }
}
