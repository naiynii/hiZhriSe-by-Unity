// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class SaveOnClick : MonoBehaviour
// {
//     public DataManager dataManager;
//     // public TMPro.TextMeshProUGUI highestScore;
//     static int scoreMax;
//     void Start()
//     {
//         dataManager.Load();
//     }
//     private void Level()
//     {
//         dataManager.Save();
//     }
//     public void Song0()
//     {
//         scoreMax = ScoreManager.totalScore;
//         DataSave.song0 = scoreMax;
//     }
//     private void Song1(string fileName)
//     {
//         string path = DataManager.GetFilePath(fileName);
//         scoreMax = ScoreManager.totalScore;
//         DataSave.song1 = scoreMax;
//         if (DataSave.song1 > 1 || !File.Exists(path))
//         { dataManager.Save(); }
//         else { }
//     }
//     private void Song2(string fileName)
//     {
//         string path = DataManager.GetFilePath(fileName);
//         scoreMax = ScoreManager.totalScore;
//         DataSave.song2 = scoreMax;
//         if (DataSave.song2 > 1 || !File.Exists(path))
//         { dataManager.Save(); }
//         else { }
//     }
//     private void Song3(string fileName)
//     {
//         string path = DataManager.GetFilePath(fileName);
//         scoreMax = ScoreManager.totalScore;
//         DataSave.song3 = scoreMax;
//         if (DataSave.song3 > 1 || !File.Exists(path))
//         { dataManager.Save(); }
//         else { }
//     }
//     public void SaveLevel()
//     {
//         if (SceneManager.GetActiveScene().name == "Chapter 1.1")
//         { if (DataSave.level < 2) { DataSave.level = 2; } }
//         if (SceneManager.GetActiveScene().name == "Chapter 1.2")
//         { if (DataSave.level < 3) { DataSave.level = 3; } }
//         Level();
//     }

// }
