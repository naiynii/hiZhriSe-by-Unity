using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro comboText;
    public TMPro.TextMeshPro lifeText;
    public static int totalScore;
    public static int comboScore;
    public static int lifeScore;
    public static string rankResult = "";
    static float accRate = 0f;
    public static float accRateRounded;
    public static float perf, nais, airr, mizs, allHit, allNote;

    void Start()
    {
        Instance = this;
        totalScore = 0;
        comboScore = 0;
        lifeScore = 100;
        perf = 0f; nais = 0f; airr = 0f; mizs = 0f; allNote = 0f;
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
        perf += 1;
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
        nais += 1;
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
        airr += 1;
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
            if (accRate >= 90f) { rankResult = "S"; }
            if (accRate >= 80f) { rankResult = "A"; }
            if (accRate >= 70f) { rankResult = "B"; }
            if (accRate >= 60f) { rankResult = "C"; }
            if (accRate >= 50f) { rankResult = "D"; }
            if (accRate <  50f) { rankResult = "F"; }
        }
        accRateRounded = (float)Math.Round(accRate * 100f) / 100f;
        Debug.Log("All hit: " + allHit);
        Debug.Log("All note: " + allNote);
        Debug.Log("Accuracy: " + accRate);
    }
    private void Update()
    {
        scoreText.text = totalScore.ToString();
        comboText.text = comboScore.ToString();
        lifeText.text = lifeScore.ToString();
    }
}
