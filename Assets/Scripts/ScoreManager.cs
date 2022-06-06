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
    public static float perf, nais, airr, mizs, allHit, allNote;

    void Start()
    {
        Instance = this;
        totalScore = 0;
        comboScore = 0;
        comboStreak = 0;
        lifeScore = 100;
        perf = 0f; nais = 0f; airr = 0f; mizs = 0f; allNote = 0f;
    }
    public static void Reset()
    {
        comboScore = 0;
    }
    public static void Perfecto()
    {
        comboScore += 1;
        totalScore += 300 * comboScore;
        lifeScore += 2;
        if (lifeScore >= 100) { lifeScore = 100; }
        perf += 1;
        Instance.hitSFX.Play();
    }
    public static void Naisu()
    {
        comboScore += 1;
        totalScore += 100 * comboScore;
        lifeScore += 1;
        if (lifeScore >= 100) { lifeScore = 100; }
        nais += 1;
        Instance.hitSFX.Play();
    }
    public static void Air()
    {
        if(comboStreak < comboScore) { comboStreak = comboScore; }
        comboScore = 0;
        lifeScore -= 1;
        if (lifeScore <= 0) { lifeScore = 0; }
        airr += 1;
    }
    public static void Misz()
    {
        if(comboStreak < comboScore) { comboStreak = comboScore; }
        comboScore = 0;
        totalScore += 0;
        lifeScore -= 3;
        if (lifeScore <= 0) { lifeScore = 0; }
        mizs += 1;
        Instance.missSFX.Play();
    }
    public static void Rate()
    {
        allHit = perf + nais;
        allNote = allHit + mizs;
        if (allNote != 0)
        {
            accRate = (allHit / allNote) * 100f;
            if      (accRate >= 90f) { rankResult = "S"; }
            else if (accRate >= 80f) { rankResult = "A"; }
            else if (accRate >= 70f) { rankResult = "B"; }
            else if (accRate >= 60f) { rankResult = "C"; }
            else if (accRate >= 50f) { rankResult = "D"; }
            else if (accRate <  50f) { rankResult = "F"; }
        }
        accRate2 = (float)Math.Round(accRate * 100f) / 100f;
    }
    private void Update()
    {
        scoreText.text = totalScore.ToString();
        comboText.text = comboScore.ToString();
        lifeText.text = lifeScore.ToString();
    }
}
