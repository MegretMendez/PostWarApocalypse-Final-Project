using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // The Start method is called before the first frame update
    void Start()
    {
        // When an Enemy object is created, it is added to the enemy list managed by EnemyManager
        EnemyManager.instance.addEnemy(this);
    }

    // The OnDestroy method is called when the Enemy object is destroyed
    void OnDestroy()
    {
        // When this Enemy object is destroyed, it is removed from the enemy list in EnemyManager
        EnemyManager.instance.removeEnemy(this);
    }
}

