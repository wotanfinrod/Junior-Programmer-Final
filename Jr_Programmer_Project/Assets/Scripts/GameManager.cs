using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const float enemyFireInterval = 1.5f;

    public List<GameObject> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        StartCoroutine(EnemyFire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyFire()
    {
        while(enemyList.Count != 0 ) 
        { 
            yield return new WaitForSeconds(enemyFireInterval);

            int numOfFire = Random.Range(1, Mathf.Min(enemyList.Count,4));
            for(int i = 0; i < numOfFire; i++)
            {
                int selectedEnemy = Random.Range(0, enemyList.Count);
                enemyList[selectedEnemy].GetComponent<Enemy>().Fire();

            }


            //int selectedEnemy = Random.Range(0, enemyList.Count);
      //  int selectedEnemy2 = Random.Range(0, enemyList.Count);
      //  enemyList[selectedEnemy].GetComponent<Enemy>().Fire();
       
        
        
        
        
        }

    }
}
