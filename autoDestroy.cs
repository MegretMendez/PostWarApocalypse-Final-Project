using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroy : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        // Destroy the bullets to for less memory consumption
        Destroy(gameObject,delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
