using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    const int upperBound = 35;
    const int lowerBound = -10;

     protected int speed;

    protected void Move()
    {
        gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void Update()
    {
    }

    protected void CheckBounds()
    {
        if(transform.position.y > upperBound && transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }


    protected void CheckBound()
    {

    }
    


}
