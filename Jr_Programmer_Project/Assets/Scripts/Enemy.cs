using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected bool leftSwing;
    private float swingTimer;
    const int swingSpeed = 5;
    
    protected int health;

    [SerializeField] GameObject enemyProjectile;


    // Start is called before the first frame update
    void Start()
    {
        leftSwing = true;
        swingTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void EnemySwing()
    {

        swingTimer += Time.deltaTime;
        if (swingTimer >= 5)    //Direction changes in every one second
        {
            leftSwing = !leftSwing;
            swingTimer = 0;

        }

        if (leftSwing)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime *  swingSpeed);

            
        }
        else
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * swingSpeed);


        }


    }

    public void Fire()
    {
        Instantiate(enemyProjectile, transform.position, enemyProjectile.transform.rotation);

    }


}
