using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    public static bool isActive = false;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (isActive == true)
            {
                
                Resume();
            }
            else
            {
               
                Pause();
            }
           
        }

    }

    public void Resume()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isActive = false;
        audio.Play();
    }

   public void Pause()
    {
       // Cursor.lockState = CursorLockMode.None;
        audio.Pause();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isActive = true;
    }
}
