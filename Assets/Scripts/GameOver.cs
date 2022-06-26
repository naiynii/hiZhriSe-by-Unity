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

    private void Lose()
    {
        if (ScoreManager.lifeScore <= 0)
        {
            gameOver.SetActive(true);
            PauseMenu.Deactive();
        }
        else if (PauseMenu.GameIsPause == true)
        {
            PauseMenu.Deactive();
        }
        else
        {
            PauseMenu.Active();
        }
    }
    
    public void Restart()
    {
        PauseMenu.Active();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenu()
    {
        SceneChanger.MainMenu();
    }
    public void QuitGame()
    {
        AudioListener.pause = false;
        SceneChanger.QuitGame();
    }

}
