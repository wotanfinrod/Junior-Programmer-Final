using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    GameManager gameManager;

    bool isTriggered; //To prevent triggering twice

    // Start is called before the first frame update
    void Start()
    {
        speed = -50;
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    protected override void DealDamage(GameObject playerGetShot)
    {
         //Bullet is gone
        Debug.Log("PLAYER GOT HIT");
        gameManager = GameObject.Find("GameHandler").GetComponent<GameManager>();
        gameManager.PlayMinectaftOof();
        gameManager.DecreasePlayerLife();

    }

    

    private void OnTriggerEnter(Collider other)
    {
        GameObject planeGotHit = other.transform.parent.parent.gameObject;
        if (planeGotHit.CompareTag("Player") && !isTriggered)
        {

            isTriggered = true;
            Destroy(gameObject);
            DealDamage(planeGotHit);
        }
    }



}
