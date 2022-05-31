using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    AudioClip audioClip;

    // Start is called before the first frame update
    
    // void Start()
    // {
    //     SongsManager.Instance.audioSource =  SongsManager.Instance.GetComponent<AudioSource>();
    //     audioClip = SongsManager.Instance.audioSource.clip;
    //     print("The song is " + SongsManager.Instance.audioSource.clip.length + " seconds long");
    // }

    // Update is called once per frame
    void Update()
    {
        WinLose();

        // if (Input.GetKey(KeyCode.Escape))
        // {
        //     Pause();
        // }
        
    }
    public void WinLose()
    {
        if (SongsManager.Instance.audioSource.clip == audioClip)
        {
            SceneManager.LoadScene("Results");
        }
        if (ScoreManager.lifeScore <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    // public void Pause()
    // {
    //     if (SongsManager.Instance.audioSource.clip == audioClip)
    //     {
    //         SceneManager.LoadScene("Results");
    //     }
    // }
}
