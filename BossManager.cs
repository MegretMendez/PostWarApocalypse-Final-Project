using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossManager : MonoBehaviour
{
    public GameObject FinalBoss; // Public reference to the FinalBoss GameObject
    private bool isObjectInstantiated = false; // Flag to check if the boss has been instantiated

    public static BossManager instance; // Static instance for Singleton pattern

    public List<FinalBoss> bosses; // List to keep track of all FinalBoss instances

    public UnityEvent OnChanged; // Event to trigger when the boss list changes


    void Awake()
    {
        // Singleton pattern to ensure only one instance of BossManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Duplicated Boss"); // Log an error if a second instance is created
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all enemies are defeated and the boss hasn't been instantiated
        if (EnemyManager.instance.enemies.Count <= 0 && !isObjectInstantiated)
        {
            // Instantiate the final boss at the current position with no rotation
            Instantiate(FinalBoss, transform.position, Quaternion.identity);
            isObjectInstantiated = true; // Set the flag to true to avoid duplicating the boss
        }
    }

    // Method to add a boss to the list
    public void addBoss(FinalBoss boss)
    {
        bosses.Add(boss); // Add the boss to the list
        OnChanged.Invoke(); // Invoke the OnChanged event
    }

    // Method to remove a boss from the list
    public void removeBoss(FinalBoss boss)
    {
        bosses.Remove(boss); // Remove the boss from the list
        OnChanged.Invoke(); // Invoke the OnChanged event
    }
}

