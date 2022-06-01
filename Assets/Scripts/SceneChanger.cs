using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainMenu()
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
    public void Dialog1_0()
    {
        SceneManager.LoadScene("Dialog 1.0");
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
    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}
