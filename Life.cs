using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public float amount; // Public variable to hold the life amount
    public UnityEvent onDeath; // Event triggered on death, used in the file ScoreOnDeath

    // Update is called once per frame
    void Update()
    {
        // Check if the life amount has reached 0 or below
        if (amount <= 0)
        {
            onDeath.Invoke(); // Invoke the onDeath event
            Destroy(gameObject); // Destroy this GameObject
        }
    }
}

