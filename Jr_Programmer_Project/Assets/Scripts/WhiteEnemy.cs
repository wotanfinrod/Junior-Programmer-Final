using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySwing();
    }
}
