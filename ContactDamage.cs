using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public float damage; // Public variable to set the amount of damage this object can inflict

    // This method is called when this GameObject's collider enters another collider
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroy this GameObject upon collision

        // Attempt to get the 'Life' component from the collided object
        Life life = other.GetComponent<Life>();

        // Check if the collided object has a 'Life' component
        if (life != null)
        {
            life.amount -= damage; // Subtract the damage amount from the collided object's life
            print(life.amount); // Print the remaining life amount to the console
        }
    }
}

