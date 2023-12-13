using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour  
{
    public int amount; // Public variable to set the amount of points to give

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Get the Life component attached to the same GameObject
        var life = GetComponent<Life>();

        // Add the GivePoints method as a listener to the onDeath event in the Life component
        life.onDeath.AddListener(GivePoints);
    }

    // Method that increments the score when called
    void GivePoints()
    {
        // Access the ScoreManager singleton instance and add the specified amount to the score
        ScoreManager.instance.amount += amount;
    }
}

