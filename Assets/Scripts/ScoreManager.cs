using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro comboText;
    static int totalScore;
    static int comboScore;
    
    void Start()
    {
        Instance = this;
        totalScore = 0;
        comboScore = 0;
    }
    public static void Hit()
    {
        comboScore += 1;
        totalScore += 200 * comboScore;
        Instance.hitSFX.Play();
    }
    public static void Miss()
    {
        totalScore += 0;
        comboScore = 0;
        Instance.missSFX.Play();    
    }
    private void Update()
    {
        scoreText.text = totalScore.ToString();
        comboText.text = comboScore.ToString();
    }
}
