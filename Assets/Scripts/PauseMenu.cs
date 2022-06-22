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
        Time.timeScale = 0f;
        GameIsPause = true;
        AudioListener.pause = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        AudioListener.pause = false;
    }
    public static void Restart()
    {
        Time.timeScale = 1f;
        GameIsPause = false;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPause = false;
        SceneChanger.MainMenu();
    }
    public static void QuitGame()
    {
        GameIsPause = false;
        SceneChanger.QuitGame();
    }
}
