using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        speed = -50;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    protected override void DealDamage(GameObject enemyGetShot)
    {
        throw new System.NotImplementedException();
    }
}
