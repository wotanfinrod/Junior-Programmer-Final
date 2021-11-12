using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void ExitButtonOnClick()
   {
        Application.Quit();
   }

    public void StartButtonOnClick()
    {
        SceneManager.LoadScene(1);
    }
}
