using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause) 
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
        GameIsPause = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Active();
        GameIsPause = false;
    }

    public void Restart()
    {
        Active();
        GameIsPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        GameIsPause = false;
        SceneChanger.MainMenu();
    }

    public void QuitGame()
    {
        GameIsPause = false;
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
