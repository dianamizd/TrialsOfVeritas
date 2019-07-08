using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    ////variable for the effect that'll play when an object is picked up
    //public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        //if the player collides with the object, Pickup() will trigger
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        ////spawn effect - like a particle effect
        ////can uncomment when we have an effect from the asset store
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        //apply effect to player

        //remove powerup object
        Destroy(gameObject);
    }
}
