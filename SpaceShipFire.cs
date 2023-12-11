using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipFire : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;

    public GameObject shootPoint2;
    public void OnFire()
    {
            GameObject clone = Instantiate(prefab);
            clone.transform.position= shootPoint.transform.position;
            clone.transform.rotation= shootPoint.transform.rotation;
            
    }

    public void OnFire1(){
            GameObject clone = Instantiate(prefab);
            clone.transform.position= shootPoint2.transform.position;
            clone.transform.rotation= shootPoint2.transform.rotation;
    }
}
