using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const float enemyFireInterval = 1f;
    bool isGameOver;

    public List<GameObject> enemyList;
    public List<GameObject> lifeList;

    [SerializeField] GameObject gameOverButton;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject youWonText;

    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioClip youWonSFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip minecraftHitSFX;
    [SerializeField] AudioClip minectaftOofSFX;

    AudioSource audioSource;

    void Start()
    {
        isGameOver = false;
        enemyList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        lifeList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Heart"));

        audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(EnemyFire());
    }

    IEnumerator EnemyFire()
    {
        while (enemyList.Count != 0 && isGameOver == false ) 
        { 
            yield return new WaitForSeconds(enemyFireInterval);

            int numOfFire = Random.Range(1, Mathf.Min(enemyList.Count,4));
            for(int i = 0; i < numOfFire; i++)
            {
                audioSource.PlayOneShot(minecraftHitSFX);
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
        isGameOver = true;
        audioSource.PlayOneShot(gameOverSFX);
        gameOverButton.SetActive(true);
        gameOverText.SetActive(true);
        GameObject.Destroy(GameObject.Find("PlayerPlane"));      
    }

    public void GameWon()
    {
        isGameOver = true;
        audioSource.PlayOneShot(youWonSFX);
        youWonText.SetActive(true);
        gameOverButton.SetActive(true);
    }

    public void PlayAgain()
    {      
        SceneManager.LoadScene(0);
    }

    
    public void PlayHit()
    {
        audioSource.PlayOneShot(hitSFX);
    }

    

    public void PlayMinectaftOof()
    {
        audioSource.PlayOneShot(minectaftOofSFX);
    }

}
