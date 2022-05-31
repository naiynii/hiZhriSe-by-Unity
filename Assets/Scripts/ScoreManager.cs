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
    public TMPro.TextMeshPro lifeText;
    static int totalScore;
    static int comboScore;
    public static int lifeScore;
    
    void Start()
    {
        Instance = this;
        totalScore = 0;
        comboScore = 0;
        lifeScore = 100;
    }
    public static void Perfecto()
    {
        comboScore += 1;
        totalScore += 300 * comboScore;
        lifeScore += 2;
        if (lifeScore >= 100)
        {
            lifeScore = 100;
        }
        Instance.hitSFX.Play();
    }
    public static void Naisu()
    {
        comboScore += 1;
        totalScore += 100 * comboScore;
        lifeScore += 1;
        if (lifeScore >= 100)
        {
            lifeScore = 100;
        }
        Instance.hitSFX.Play();
    }
    public static void Air()
    {
        comboScore = 0;
        lifeScore -= 1;
        if (lifeScore <= 0)
        {
            lifeScore = 0;
        }
    }
    public static void Misz()
    {
        comboScore = 0;
        totalScore += 0;
        lifeScore -= 3;
        if (lifeScore <= 0)
        {
            lifeScore = 0;
        }
        Instance.missSFX.Play();    
    }
    private void Update()
    {
        scoreText.text = totalScore.ToString();
        comboText.text = comboScore.ToString();
        lifeText.text = lifeScore.ToString();
    }
}
