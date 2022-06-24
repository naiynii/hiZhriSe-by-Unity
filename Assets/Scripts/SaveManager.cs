using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private DataManager data;
    // private string path = "";
    private string persistentPath = "";
    private int s0, s1, s2, s3, lvl;

    void Start()
    {
        CreatePlayerData();
        SetPaths();
    }

    private void CreatePlayerData()
    {
        data = new DataManager(0, 0, 0, 0, 1);
    }

    private void SetPaths()
    {
        // path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.S))
    //         SaveData();

    //     if (Input.GetKeyDown(KeyCode.L))
    //         LoadData();
    // }

    public void SaveData()
    {
        string savePath = persistentPath;

        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();

        DataManager data = JsonUtility.FromJson<DataManager>(json);
        Debug.Log(data.ToString());
    }
    public void SaveOnClick()
    {
        if (SceneManager.GetActiveScene().name == "Chapter 1.0")
        { if (data.level < 1) { data.level = 1; SaveData(); } }

        if (SceneManager.GetActiveScene().name == "Chapter 1.1")
        { if (data.level < 2) { data.level = 2; SaveData(); } }

        if (SceneManager.GetActiveScene().name == "Chapter 1.2")
        { if (data.level < 3) { data.level = 3; SaveData(); } }

        if (SceneManager.GetActiveScene().name == "Song 0")
        {
            s0 = ScoreManager.totalScore;
            if (s0 > data.song0) { data.song0 = s0; SaveData(); }
        }

        if (SceneManager.GetActiveScene().name == "Song 1")
        {
            s1 = ScoreManager.totalScore;
            if (s1 > data.song1) { data.song1 = s1; SaveData(); }
        }

        if (SceneManager.GetActiveScene().name == "Song 2")
        {
            s2 = ScoreManager.totalScore;
            if (s2 > data.song2) { data.song2 = s2; SaveData(); }
        }
        if (SceneManager.GetActiveScene().name == "Song 3")
        {
            s3 = ScoreManager.totalScore;
            if (s3 > data.song3) { data.song3 = s3; SaveData(); }
        }
    }

}
