using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause) 
            { 
                Resume();
            } 
            else 
            {
                Pause();
            }
        }
    }
    
    void Pause()
    {
        pauseMenu.SetActive(true);
        Deactive();
        gameIsPause = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Active();
        gameIsPause = false;
    }

    public void Restart()
    {
        Active();
        gameIsPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        gameIsPause = false;
        SceneChanger.MainMenu();
    }

    public void QuitGame()
    {
        gameIsPause = false;
        AudioListener.pause = false;
        SceneChanger.QuitGame();
    }

    public static void Active()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
    
    public static void Deactive()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
}
