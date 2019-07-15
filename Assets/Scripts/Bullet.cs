using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    // Start is called before the first frame update

    public float Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * Speed * Time.smoothDeltaTime);
    }

    private void OnCollisionEnter(Collision Player1)
    {
      
    }

   
}
