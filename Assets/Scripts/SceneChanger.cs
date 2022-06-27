using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void ChapterMyxxe()
    {
        SceneManager.LoadScene("Myxxe Chapter");
    }

    public void Story1_0()
    {
        SceneManager.LoadScene("Chapter 1.0");
    }

    public void Story1_1()
    {
        SceneManager.LoadScene("Chapter 1.1");
    }

    public void Story1_2()
    {
        SceneManager.LoadScene("Chapter 1.2");
    }

    public void Story1_3()
    {
        SceneManager.LoadScene("Chapter 1.3");
    }

    public void Thanks()
    {
        SceneManager.LoadScene("Thanks");
    }

    public void Dialog1_1()
    {
        SceneManager.LoadScene("Dialog 1.1");
    }

    public void Dialog1_2()
    {
        SceneManager.LoadScene("Dialog 1.2");
    }

    public void Dialog1_3()
    {
        SceneManager.LoadScene("Dialog 1.3");
    }

    public void Song0()
    {
        SceneManager.LoadScene("Song 0");
    }

    public void Song1()
    {
        SceneManager.LoadScene("Song 1");
    }
    
    public void Song2()
    {
        SceneManager.LoadScene("Song 2");
    }

    public void Song3()
    {
        SceneManager.LoadScene("Song 3");
    }

    public static void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}
