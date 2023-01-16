using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        Cronometro.time = 0;
    }

   public void Credits()
    {

        SceneManager.LoadScene("Credits");
    }

   public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ModoRonda()
    {
        SceneManager.LoadScene("LevelRounds");
        Time.timeScale = 1f;
        Cronometro.time = 0;
    }
}
