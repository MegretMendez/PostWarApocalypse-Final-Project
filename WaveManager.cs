using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance; // Singleton instance of WaveManager
    public List<WaveSpawn> waves; // List to keep track of all wave spawns
    public UnityEvent onChanged; // Event triggered when there is a change in the waves
   
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Implementing Singleton pattern to ensure only one instance of WaveManager exists
        if (instance == null)
        {
            instance = this; // If instance is null, assign this object as the instance
        }
        else
        {
            // Log an error if a second instance is created
            Debug.LogError("Duplicated Waves Manager");
        }
    }

    // Method to add a wave to the list of wave spawns
    public void addWave(WaveSpawn wave)
    {
        waves.Add(wave); // Add the wave to the list
        onChanged.Invoke(); // Invoke the onChanged event to notify any listeners of the change
    }

    // Method to remove a wave from the list of wave spawns
    public void removeWave(WaveSpawn wave)
    {
        waves.Remove(wave); // Remove the wave from the list
        onChanged.Invoke(); // Invoke the onChanged event to notify any listeners of the change
    }

}

