using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySwing();
    }
}
