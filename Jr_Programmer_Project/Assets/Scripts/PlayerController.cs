using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const int playerLeftBound = -48;
    const int playerRightBound = 53;

    [SerializeField] GameObject playerProjectile;
    


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Fire();


    }



    void MovePlayer()
    {
        Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,-Camera.main.transform.position.z);
        Vector3 playerNewPoint = new Vector3(Camera.main.ScreenToWorldPoint(screenPoint).x, transform.position.y, transform.position.z);
        
        if(playerNewPoint.x > playerLeftBound && playerNewPoint.x < playerRightBound) //Bound check
        {
            transform.position = playerNewPoint;
        }

    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(playerProjectile, transform.position, playerProjectile.transform.rotation);
        }

    }



}
