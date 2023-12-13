using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] public Life playerLife; // Reference to the player's Life component
    
    // Update is called once per frame
    void Update()
    {
        // Add a listener to the player's death event
        playerLife.onDeath.AddListener(OnPlayerDied);

        // Add a listener to the BossManager's onChanged event
        BossManager.instance.OnChanged.AddListener(checkWinConditions);
    }

    // Method to check win conditions of the game
    void checkWinConditions()
    {
        // Check if the number of bosses is zero or less
        if (BossManager.instance.bosses.Count <= 0)
        {
            print("Enemies Defeated...You are VICTORIOUS"); // Print victory message

            // Stop playing the game in the Unity Editor
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    // Method called when the player dies
    void OnPlayerDied()
    {
        print("Mission Failed, We'll Get Em Next Time"); // Print failure message

        // Stop playing the game in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

