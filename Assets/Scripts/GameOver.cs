using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    void Update()
    {
        Lose();
    }
    public void Lose()
    {
        if (ScoreManager.lifeScore <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }
    public void Restart()
    {
        PauseMenu.Restart();
    }
    public void LoadMenu()
    {
        PauseMenu.LoadMenu();
    }
    public void QuitGame()
    {
        PauseMenu.QuitGame();
    }

}
