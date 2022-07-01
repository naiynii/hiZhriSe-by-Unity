using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    public static void Easy()
    {
        SongManager.noteTime = 1.00f;
        Background.speed = 4f;
    }

    public static void Normal()
    {
        SongManager.noteTime = 0.80f;
        Background.speed = 5f;
    }

    public static void Hard()
    {
        SongManager.noteTime = 0.60f;
        Background.speed = 6f;
    }
    
    public static void Retry()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
