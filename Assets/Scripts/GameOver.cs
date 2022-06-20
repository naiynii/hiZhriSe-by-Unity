using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public AudioSource youDead;

    void Update()
    {
        Lose();
    }
    public void Lose()
    {
        if (ScoreManager.lifeScore <= 0)
        {
            youDead.Play();
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else if (PauseMenu.GameIsPause == true)
        {
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
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneChanger.MainMenu();
    }
    public void QuitGame()
    {
        SceneChanger.QuitGame();
    }

}
