using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLight : MonoBehaviour
{
    // in this script we will turn off the light upon playing time to simulate a Post War-ish environment
    // Start is called before the first frame update
    void Start()
    {
        GameObject lightGameObject = GameObject.Find("Directional Light"); 
        if (lightGameObject != null)
        {
            lightGameObject.SetActive(false);
        }
    }

    
}
