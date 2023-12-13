using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BossManager.instance.addBoss(this);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        BossManager.instance.removeBoss(this);
    }
}
