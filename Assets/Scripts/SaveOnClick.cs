using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveOnClick : MonoBehaviour
{
    public static int scoreMax;
    // public static DataManager dataManager;
    public static LevelChapter level;
    private void Level()
    {
        DataManager.SaveLevel();
    }
    private void Song0(string fileName)
    {
        string path = DataManager.GetFilePath(fileName);
        scoreMax = ScoreManager.totalScore;
        SaveManager.song0 = scoreMax;
        if (SaveManager.song0 > 1 || !File.Exists(path))
        { DataManager.SaveScore(); }
        else { }
    }
    private void Song1(string fileName)
    {
        string path = DataManager.GetFilePath(fileName);
        scoreMax = ScoreManager.totalScore;
        SaveManager.song1 = scoreMax;
        if (SaveManager.song1 > 1 || !File.Exists(path))
        { DataManager.SaveScore(); }
        else { }
    }
    private void Song2(string fileName)
    {
        string path = DataManager.GetFilePath(fileName);
        scoreMax = ScoreManager.totalScore;
        SaveManager.song2 = scoreMax;
        if (SaveManager.song2 > 1 || !File.Exists(path))
        { DataManager.SaveScore(); }
        else { }
    }
    private void Song3(string fileName)
    {
        string path = DataManager.GetFilePath(fileName);
        scoreMax = ScoreManager.totalScore;
        SaveManager.song3 = scoreMax;
        if (SaveManager.song3 > 1 || !File.Exists(path))
        { DataManager.SaveScore(); }
        else { }
    }
    public void SaveLevel()
    {
        if (SceneManager.GetActiveScene().name == "Chapter 1.1")
        { if (level.levelChapter < 2) { level.levelChapter = 2; } }
        if (SceneManager.GetActiveScene().name == "Chapter 1.2")
        { if (level.levelChapter < 3) { level.levelChapter = 3; } }
        Level();
    }
    public void SaveSong0()
    {
        Song0("");
    }
    public void SaveSong1()
    {
        Song1("");
    }
    public void SaveSong2()
    {
        Song2("");
    }
    public void SaveSong3()
    {
        Song3("");
    }

}
