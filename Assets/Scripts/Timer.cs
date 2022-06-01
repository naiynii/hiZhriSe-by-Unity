using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

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
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        AudioListener.pause = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        AudioListener.pause = false;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
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
