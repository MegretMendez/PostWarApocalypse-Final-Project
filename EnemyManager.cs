using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; // Static instance for the Singleton pattern
    public List<Enemy> enemies; // List to keep track of all Enemy instances

    public UnityEvent onChanged; // Event to trigger when the enemy list changes

    // Awake is called when the script instance is being loaded
    // Singleton Design Pattern
    void Awake()
    {
        // Check if instance is null, which means this is the first EnemyManager instance
        if (instance == null)
        {
            instance = this; // Assign this object as the instance
        }
        else
        {
            // If a second instance is created, log an error
            Debug.LogError("Duplicated Enemies");
        }
    }

    // Method to add an enemy to the list
    public void addEnemy(Enemy enemy)
    {
        enemies.Add(enemy); // Add the enemy to the list
        onChanged.Invoke(); // Invoke the onChanged event
    }

    // Method to remove an enemy from the list
    public void removeEnemy(Enemy enemy)
    {
        enemies.Remove(enemy); // Remove the enemy from the list
        onChanged.Invoke(); // Invoke the onChanged event
    }
}

