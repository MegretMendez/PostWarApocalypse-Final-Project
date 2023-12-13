using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public GameObject prefab; // The enemy prefab that will be spawned

    public float startTime; // Time before the spawner starts working
    public float endTime; // Time when the spawner will stop
    public float spawnRate; // Rate at which the enemies are spawned

    // Start is called before the first frame update
    void Start()
    {
        // Register this wave spawner with the WaveManager
        WaveManager.instance.addWave(this);

        // Start spawning enemies at regular intervals after startTime
        InvokeRepeating("Spawn", startTime, spawnRate);

        // Schedule the end of the spawner after endTime
        Invoke("EndSpawner", endTime);
    }

    // Method for spawning an enemy
    void Spawn()
    {
        // Instantiate the enemy prefab at this object's position and rotation
        Instantiate(prefab, transform.position, transform.rotation);
    }

    // Method to end the spawning and deregister the spawner
    void EndSpawner()
    {
        // Remove this wave spawner from the WaveManager
        WaveManager.instance.removeWave(this);

        // Cancel all Invoke calls on this script
        CancelInvoke();
    }
}
