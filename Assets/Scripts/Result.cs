using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject resultScene;
    public TMPro.TextMeshProUGUI songName, finalRank, hitRate;
    public TMPro.TextMeshProUGUI maxScore, maxCombo;
    public TMPro.TextMeshProUGUI countPerfecto, countNaisu, countAir, countMisz;
    static int scoreMax, comboMax;
    static float allPerfecto, allNaisu, allAir, allMisz;
    bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreMax = PlayerPrefs.GetInt("scoreMax", scoreMax);
        comboMax = PlayerPrefs.GetInt("comboMax", comboMax);

        allPerfecto = PlayerPrefs.GetFloat("allPerfecto", allPerfecto);
        allNaisu = PlayerPrefs.GetFloat("allNaisu", allNaisu);
        allAir = PlayerPrefs.GetFloat("allAir", allAir);
        allMisz = PlayerPrefs.GetFloat("allMisz", allMisz);
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnd == true)
        {
            return;
        }
        if (SongsManager.songsDuration > 0)
        {
            SongsManager.songsDuration -= Time.deltaTime;
        }
        else if (SongsManager.songsDuration <= 0)
        {
            resultScene.SetActive(true);
            Time.timeScale = 0f;
            Rate();

            songName.text = SongsManager.songsName;
            finalRank.text = ScoreManager.rankResult;
            hitRate.text = ScoreManager.accRate2.ToString();
            scoreMax = ScoreManager.totalScore;
            maxScore.text = scoreMax.ToString();
            
            comboMax = ScoreManager.comboStreak;
            PlayerPrefs.SetInt("comboMax", comboMax);
            maxCombo.text = comboMax.ToString();
            allPerfecto = ScoreManager.perf;
            countPerfecto.text = allPerfecto.ToString();
            allNaisu = ScoreManager.nais;
            countNaisu.text = allNaisu.ToString();
            allAir = ScoreManager.airr;
            countAir.text = allAir.ToString();
            allMisz = ScoreManager.mizs;
            countMisz.text = allMisz.ToString();

            isEnd = true;
            
            Debug.Log("All notes: "  + ScoreManager.allNote);
            Debug.Log("Hit count: "  + ScoreManager.allHit + " (Perfecto!! " + ScoreManager.perf + ", Naisu! " + ScoreManager.nais + ")");
            Debug.Log("Miss count: " + ScoreManager.mizs);
            Debug.Log("Hit streak: " + comboMax);
            Debug.Log("Accuracy: "   + ScoreManager.accRate2 + " %");
            
        }
    }
    private void Rate()
    {
        ScoreManager.Rate();
    }
}
