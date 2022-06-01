using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}
