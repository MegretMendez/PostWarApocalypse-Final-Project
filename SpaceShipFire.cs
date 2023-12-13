using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipFire : MonoBehaviour
{
    public GameObject prefab; // Prefab of the projectile to be instantiated
    public GameObject shootPoint; // The point from which the projectile will be fired

    public GameObject shootPoint2; // An alternative shoot point for firing the projectile

    // This method is called when the fire action is triggered
    public void OnFire()
    {
        // Create a clone of the projectile prefab
        GameObject clone = Instantiate(prefab);

        // Set the position of the cloned projectile to the first shoot point's position
        clone.transform.position = shootPoint.transform.position;

        // Set the rotation of the cloned projectile to the first shoot point's rotation
        clone.transform.rotation = shootPoint.transform.rotation;
    }

    // This method is similar to OnFire but uses the second shoot point
    public void OnFire1()
    {
        // Create a clone of the projectile prefab
        GameObject clone = Instantiate(prefab);

        // Set the position of the cloned projectile to the second shoot point's position
        clone.transform.position = shootPoint2.transform.position;

        // Set the rotation of the cloned projectile to the second shoot point's rotation
        clone.transform.rotation = shootPoint2.transform.rotation;
    }
}
