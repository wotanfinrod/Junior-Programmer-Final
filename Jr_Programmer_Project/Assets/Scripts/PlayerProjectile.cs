using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    bool isUsed;

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;
        speed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();

     
    }

    protected override void DealDamage(GameObject planeGetShot)
    {
        Destroy(gameObject);
        planeGetShot.GetComponent<Enemy>().TakeDamage();
    }

    private void OnCollisionEnter(Collision collision)
    {


        GameObject enemyGotHit = collision.transform.parent.parent.gameObject;
        if (enemyGotHit.CompareTag("Enemy") && !isUsed)
        {
            isUsed = true;
            DealDamage(enemyGotHit);
        }
        

    }


}
