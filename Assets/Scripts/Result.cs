using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameObject resultScene;
    public TMPro.TextMeshProUGUI songName, finalRank, hitRate;
    public TMPro.TextMeshProUGUI maxScore, maxCombo;
    public TMPro.TextMeshProUGUI countPerfecto, countNaisu, countAir, countMisz;
    static int scoreMax, comboMax;
    static float nPerfecto, nNaisu, nAirr, nMisz;
    public Button continueButton;
    bool isEnd = false;

    void Start()
    {
        scoreMax = PlayerPrefs.GetInt("scoreMax", scoreMax);
        nPerfecto = PlayerPrefs.GetFloat("nPerfecto", nPerfecto);
        nNaisu = PlayerPrefs.GetFloat("nNaisu", nNaisu);
        nAirr = PlayerPrefs.GetFloat("nAir", nAirr);
        nMisz = PlayerPrefs.GetFloat("nMisz", nMisz);
    }

    void Update()
    {
        if (isEnd == true)
        {
            return;
        }
        if (AudioManager.songsDuration > 0)
        {
            AudioManager.songsDuration -= Time.deltaTime;
        }
        else if (AudioManager.songsDuration <= 0)
        {
            resultScene.SetActive(true);
            Time.timeScale = 0f;
            ScoreManager.Rate();

            songName.text = AudioManager.songsName;
            finalRank.text = ScoreManager.rankResult;
            hitRate.text = ScoreManager.accRate2.ToString();
            scoreMax = ScoreManager.totalScore;
            maxScore.text = scoreMax.ToString();
            comboMax = ScoreManager.comboStreak;
            maxCombo.text = comboMax.ToString();
            nPerfecto = ScoreManager.nPer;
            countPerfecto.text = nPerfecto.ToString();
            nNaisu = ScoreManager.nNai;
            countNaisu.text = nNaisu.ToString();
            nAirr = ScoreManager.nAir;
            countAir.text = nAirr.ToString();
            nMisz = ScoreManager.nMis;
            countMisz.text = nMisz.ToString();

            if (ScoreManager.rankResult == "F" || ScoreManager.rankResult == "D")
            {
                continueButton.enabled = false;
            }

            isEnd = true;

            Debug.Log("Notes count: " + ScoreManager.nNote);
            Debug.Log("Hit: " + ScoreManager.nHit + " (Perfecto!! " + ScoreManager.nPer + ", Naisu! " + ScoreManager.nNai + ")");
            Debug.Log("Miss: " + ScoreManager.nMis);
            Debug.Log("Streak: " + comboMax);
            Debug.Log("Accuracy: " + ScoreManager.accRate2 + " %");
        }
    }

}
