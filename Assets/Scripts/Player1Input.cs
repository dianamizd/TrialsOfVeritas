using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Input : MonoBehaviour
{
    public float h;

    public float v;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(h, 0, v);

        if (Input.GetButtonDown("Horizontal"))
        {
            print("left/right movement");
        } 

        if (Input.GetButtonDown("Vertical"))
        {
            print("up/down movement");
        }

        h = Input.GetAxis("Horizontal");

        v = Input.GetAxis("Vertical");

        transform.Translate(movement * Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(movement);

        Debug.Log(h);
    }
}
