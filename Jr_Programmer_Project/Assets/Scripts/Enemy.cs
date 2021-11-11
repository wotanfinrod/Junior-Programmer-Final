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
    GameManager gameManager;

     void Start()
    {    
        leftSwing = true;
        swingTimer = 0;
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
            gameObject.transform.Translate(Vector3.left * Time.deltaTime *  swingSpeed);
    
        
        else       
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * swingSpeed);

    }

    public void Fire()
    {
        Instantiate(enemyProjectile, transform.position, enemyProjectile.transform.rotation);
    }

    public void TakeDamage()
    {
        gameManager = GameObject.Find("GameHandler").GetComponent<GameManager>();
        gameManager.PlayHit();        
        health--;
        if (health == 0) //Plane is dead
        {
            gameManager.enemyList.Remove(gameObject); //Remove from the enemies list
            Destroy(gameObject); //Destroy the plane
            if(gameManager.enemyList.Count == 0)
            {
                gameManager.GameWon();
            }
        }
    }
}
