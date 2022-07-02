using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX, missSFX;
    public TMPro.TextMeshPro scoreText, comboText, lifeText;
    public static int totalScore, comboScore, lifeScore, comboStreak;
    public static string rankResult = "";
    static float accRate = 0f;
    public static float accRate2;
    public static float nPer, nNai, nAir, nMis, nHit, nNote;

    void Start()
    {
        Instance = this;
        totalScore = 0;
        comboScore = 0;
        comboStreak = 0;
        lifeScore = 100;
        nPer = 0f; nNai = 0f; nAir = 0f; nMis = 0f; nNote = 0f;
    }

    public static void Perfecto()
    {
        lifeScore += 2;
        comboScore += 1;
        totalScore += 300 * comboScore;
        nPer += 1;
        Instance.hitSFX.Play();

        if (lifeScore > 100)
        {
            lifeScore = 100;
        }
        if (comboStreak < comboScore)
        {
            comboStreak = comboScore;
        }
    }

    public static void Naisu()
    {
        lifeScore += 1;
        comboScore += 1;
        totalScore += 100 * comboScore;
        nNai += 1;
        Instance.hitSFX.Play();

        if (lifeScore > 100)
        {
            lifeScore = 100;
        }
        if (comboStreak < comboScore)
        {
            comboStreak = comboScore;
        }
    }

    public static void Air()
    {
        if (comboStreak < comboScore)
        {
            comboStreak = comboScore;
        }

        lifeScore -= 1;
        comboScore = 0;
        nAir += 1;

        if (lifeScore < 0)
        {
            lifeScore = 0;
        } 
    }

    public static void Misz()
    {
        // if (comboStreak < comboScore)
        // {
        //     comboStreak = comboScore;
        // }

        // lifeScore -= 3;
        // comboScore = 0;
        nMis += 1;
        Instance.missSFX.Play();

        // if (lifeScore < 0)
        // {
        //     lifeScore = 0;
        // }
    }

    public static void Rate()
    {
        nHit = nPer + nNai;
        nNote = nHit + nMis;

        if (nNote != 0)
        {
            accRate = (nHit / nNote) * 100f;
            if (accRate >= 90f) { rankResult = "S"; }
            else if (accRate >= 80f) { rankResult = "A"; }
            else if (accRate >= 70f) { rankResult = "B"; }
            else if (accRate >= 60f) { rankResult = "C"; }
            else if (accRate >= 50f) { rankResult = "D"; }
            else if (accRate <  50f) { rankResult = "F"; }
        }
        
        accRate2 = (float)Math.Round(accRate * 100f) / 100f;
    }
    
    void Update()
    {
        scoreText.text = totalScore.ToString();
        comboText.text = comboScore.ToString();
        lifeText.text = lifeScore.ToString();
    }
    
}
