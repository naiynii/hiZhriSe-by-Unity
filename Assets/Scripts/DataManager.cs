using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static SaveManager scores;
    public static LevelChapter level;
    private static string fileScore = "highScore.txt";
    private static string fileLevel = "levelChapter.txt";

    public static void SaveScore()
    {
        string json = JsonUtility.ToJson(scores);
        WriteToFile(fileScore, json);
    }
    public static void SaveLevel()
    {
        string json = JsonUtility.ToJson(level);
        WriteToFile(fileLevel, json);
    }
    public void LoadScore()
    {
        scores = new SaveManager();
        string json = ReadFromFile(fileScore);
    }
    public void LoadLevel()
    {
        level = new LevelChapter();
        string json = ReadFromFile(fileLevel);
    }
    private static void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }
    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json  = reader.ReadToEnd();
                return json;
            }
        }
        else
            Debug.LogWarning("File not found");
        return "";
    }
    public static string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

}
