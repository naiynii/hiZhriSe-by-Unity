using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject resultScene;
    public TMPro.TextMeshProUGUI songName, finalRank, hitRate;
    public TMPro.TextMeshProUGUI maxScore, maxCombo;
    public TMPro.TextMeshProUGUI countPerfecto, countNaisu, countAir, countMisz;
    // static string nameOfSong;
    static int scoreMax, comboMax;
    static float  allPerfecto, allNaisu, allAir, allMisz;
    bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        // nameOfSong = SongsManager.audioSource.clip.ToString();
        // songName.text = nameOfSong.ToString();

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
        if (SongsManager.delay > 0)
        {
            SongsManager.delay -= Time.deltaTime;
        }
        else if (SongsManager.delay <= 0)
        {
            
            resultScene.SetActive(true);
            Time.timeScale = 0f;
            Rate();
            
            if (ScoreManager.comboScore >= comboMax)
            {
                comboMax = ScoreManager.comboScore;
                maxCombo.text = comboMax.ToString();
                PlayerPrefs.SetInt("comboMax", comboMax);
            }

            songName.text = SongsManager.songName;
            finalRank.text = ScoreManager.rankResult;
            hitRate.text = ScoreManager.accRateRounded.ToString();

            scoreMax = ScoreManager.totalScore;
            maxScore.text = scoreMax.ToString();
            
            allPerfecto = ScoreManager.perf;
            countPerfecto.text = allPerfecto.ToString();
            allNaisu = ScoreManager.nais;
            countNaisu.text = allNaisu.ToString();
            allAir = ScoreManager.airr;
            countAir.text = allAir.ToString();
            allMisz = ScoreManager.mizs;
            countMisz.text = allMisz.ToString();

            PlayerPrefs.SetInt("scoreMax", scoreMax);
            PlayerPrefs.GetFloat("allPerfecto", allPerfecto);
            PlayerPrefs.GetFloat("allNaisu", allNaisu);
            PlayerPrefs.GetFloat("allAir", allAir);
            PlayerPrefs.GetFloat("allMisz", allMisz);

            isEnd = true;
        }
    }
    private void Rate()
    {
        ScoreManager.Rate();
    }
}
