using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const float enemyFireInterval = 1.5f;

    public List<GameObject> enemyList;
    public List<GameObject> lifeList;

    [SerializeField] GameObject gameOverButton;
    [SerializeField] GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        lifeList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Heart"));

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
        }

    }

    public void DecreasePlayerLife()
    {
        lifeList[lifeList.Count - 1].SetActive(false);
        lifeList.RemoveAt(lifeList.Count - 1);

        if (lifeList.Count == 0) GameOver();

    }

    void GameOver()
    {
        gameOverButton.SetActive(true);
        gameOverText.SetActive(true);

        GameObject.Destroy(GameObject.Find("PlayerPlane"));
        
    }

    public void PlayAgain()
    {
        
        SceneManager.LoadScene(0);
    }

}
