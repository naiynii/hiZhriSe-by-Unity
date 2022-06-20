using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI chapterText;
    public static string chapCounter = "";
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Chapter 1.0")
        {
            chapCounter = "1-0";
        }
        if (SceneManager.GetActiveScene().name == "Chapter 1.1")
        {
            chapCounter = "1-1";
        }
        if (SceneManager.GetActiveScene().name == "Chapter 1.2")
        {
            chapCounter = "1-2";
        }
        if (SceneManager.GetActiveScene().name == "Chapter 1.3")
        {
            chapCounter = "1-3";
        }
        chapterText.text = chapCounter.ToString();
    }
}
