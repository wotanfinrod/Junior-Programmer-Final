using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySwing();
    }
}
