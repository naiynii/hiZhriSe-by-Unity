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
    
    // AudioClip audioClip;

    // Start is called before the first frame update

    // void Start()
    // {
    //     songsManager = GetComponent<SongsManager>();
    //     SongsManager.Instance.audioSource =  SongsManager.Instance.GetComponent<AudioSource>();
    //     audioClip = SongsManager.Instance.audioSource.clip;
    //     print("The song is " + SongsManager.Instance.audioSource.clip.length + " seconds long");
        
    // }

    // Update is called once per frame

    // void Update()
    // {
    //     WinLose();

    //     // if (Input.GetKey(KeyCode.Escape))
    //     // {
    //     //     Pause();
    //     // }
        
    // }

    // public void WinLose()
    // {
    //     if (SongsManager.Instance.audioSource.clip == audioClip)
    //     {
    //         SceneManager.LoadScene("Results");
    //     }
    //     if (ScoreManager.lifeScore <= 0)
    //     {
    //         SceneManager.LoadScene("Game Over");
    //     }
    // }
    // public void Pause()
    // {
    //     if (SongsManager.Instance.audioSource.clip == audioClip)
    //     {
    //         SceneManager.LoadScene("Results");
    //     }
    // }
}
