using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private Data0 data0; private Data1 data1;
    private Data2 data2; private Data3 data3; private DataLvl dataLvl;
    public static string path0 = "", path1 = "", path2 = "", path3 = "", pathLvl = "";

    void Start()
    {
        CreatePlayerData();
        SetPaths();
    }

    private void CreatePlayerData()
    {
        data0 = new Data0(0);
        data1 = new Data1(0);
        data2 = new Data2(0);
        data3 = new Data3(0);
        dataLvl = new DataLvl(1);
    }

    public static void SetPaths()
    {
        path0 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "song-0.json";
        path1 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "song-1.json";
        path2 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "song-2.json";
        path3 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "song-3.json";
        pathLvl = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "level-chapter.json";
    }

    private void SaveData()
    {
        WriteData();
    }

    public void SaveOnClick()
    {
        SaveCheck();
    }

    private void SaveCheck()
    {
        var yourScore = ScoreManager.totalScore;

        if (SceneManager.GetActiveScene().name == "Chapter 1.0")
        {
            if (!File.Exists(path0))
            {
                if (yourScore > data0.song0)
                {
                    data0.song0 = yourScore;
                    SaveData();
                }
            }
            else
            {
                using StreamReader reader = new StreamReader(path0);
                string json = reader.ReadToEnd();
                reader.Dispose();

                Data0 high0 = JsonUtility.FromJson<Data0>(json);
                high0.song0 = int.Parse(high0.song0.ToString());
                
                Debug.Log("Your Score: " + yourScore);
                Debug.Log("Highest Score: " + high0.song0);

                if (yourScore > high0.song0)
                {
                    data0.song0 = yourScore;
                    SaveData();
                }
            }

            // if (!File.Exists(pathLvl))
            // {
            //     dataLvl.level = 2;
            //     SaveData();
            // }
        }

        if (SceneManager.GetActiveScene().name == "Chapter 1.1")
        {
            if (!File.Exists(pathLvl))
            {
                dataLvl.level = 2;
                SaveData();
            }
        }

        if (SceneManager.GetActiveScene().name == "Chapter 1.2")
        {
            if (dataLvl.level < 3)
            {
                dataLvl.level = 3;
                SaveData();
            }
            
            // using StreamReader reader = new StreamReader(pathLvl);
            // string json = reader.ReadToEnd();
            // reader.Dispose();

            // DataLvl levels = JsonUtility.FromJson<DataLvl>(json);
            // levels.level = int.Parse(levels.level.ToString());
            
            // Debug.Log("Your Level: " + levels.level);

            // if (levels.level < 3)
            // {
            //     dataLvl.level = 3;
            //     SaveData();
            // }
        }

        if (SceneManager.GetActiveScene().name == "Song 0")
        {
            if (!File.Exists(pathLvl))
            {
                if (yourScore > data0.song0)
                {
                    data0.song0 = yourScore;
                    SaveData();
                }
            }
            else
            {
                using StreamReader reader = new StreamReader(path0);
                string json = reader.ReadToEnd();
                reader.Dispose();

                Data0 high0 = JsonUtility.FromJson<Data0>(json);
                high0.song0 = int.Parse(high0.song0.ToString());
                
                Debug.Log("Your Score: " + yourScore);
                Debug.Log("Highest Score: " + high0.song0);

                if (yourScore > high0.song0)
                {
                    data0.song0 = yourScore;
                    SaveData();
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Song 1")
        {
            if (!File.Exists(path1))
            {
                if (yourScore > data1.song1)
                {
                    data1.song1 = yourScore;
                    SaveData();
                }
            }
            else
            {
                using StreamReader reader = new StreamReader(path1);
                string json = reader.ReadToEnd();
                reader.Dispose();

                Data1 high1 = JsonUtility.FromJson<Data1>(json);
                high1.song1 = int.Parse(high1.song1.ToString());
                
                Debug.Log("Your Score: " + yourScore);
                Debug.Log("Highest Score: " + high1.song1);

                if (yourScore > high1.song1)
                {
                    data1.song1 = yourScore;
                    SaveData();
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Song 2")
        {
            if (!File.Exists(path2))
            {
                if (yourScore > data2.song2)
                {
                    data2.song2 = yourScore;
                    SaveData();
                }
            }
            else
            {
                using StreamReader reader = new StreamReader(path2);
                string json = reader.ReadToEnd();
                reader.Dispose();

                Data2 high2 = JsonUtility.FromJson<Data2>(json);
                high2.song2 = int.Parse(high2.song2.ToString());
                
                Debug.Log("Your Score: " + yourScore);
                Debug.Log("Highest Score: " + high2.song2);

                if (yourScore > high2.song2)
                {
                    data2.song2 = yourScore;
                    SaveData();
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "Song 3")
        {
            if (!File.Exists(path3))
            {
                if (yourScore > data1.song1)
                {
                    data3.song3 = yourScore;
                    SaveData();
                }
            }
            else
            {
                using StreamReader reader = new StreamReader(path3);
                string json = reader.ReadToEnd();
                reader.Dispose();

                Data3 high3 = JsonUtility.FromJson<Data3>(json);
                high3.song3 = int.Parse(high3.song3.ToString());
                
                Debug.Log("Your Score: " + yourScore);
                Debug.Log("Highest Score: " + high3.song3);

                if (yourScore > high3.song3)
                {
                    data3.song3 = yourScore;
                    SaveData();
                }
            }
        }
    }

    private void WriteData()
    {
        if (SceneManager.GetActiveScene().name == "Chapter 1.0")
        {
            Debug.Log("Saving Data at " + path0);
            string json = JsonUtility.ToJson(data0);
            Debug.Log(json);
            using StreamWriter writer = new StreamWriter(path0);
            writer.Write(json);

            // Debug.Log("Saving Data at " + pathLvl);
            // string json = JsonUtility.ToJson(dataLvl);
            // Debug.Log(json);
            // using StreamWriter writer = new StreamWriter(pathLvl);
            // writer.Write(json);
        }
        if (SceneManager.GetActiveScene().name == "Song 0")
        {
            Debug.Log("Saving Data at " + path0);
            string json = JsonUtility.ToJson(data0);
            Debug.Log(json);
            using StreamWriter writer = new StreamWriter(path0);
            writer.Write(json);
        }
        if (SceneManager.GetActiveScene().name == "Song 1")
        {
            Debug.Log("Saving Data at " + path1);
            string json = JsonUtility.ToJson(data1);
            Debug.Log(json);
            using StreamWriter writer = new StreamWriter(path1);
            writer.Write(json);
        }
        if (SceneManager.GetActiveScene().name == "Song 2")
        {
            Debug.Log("Saving Data at " + path2);
            string json = JsonUtility.ToJson(data2);
            Debug.Log(json);
            using StreamWriter writer = new StreamWriter(path2);
            writer.Write(json);
        }
        if (SceneManager.GetActiveScene().name == "Song 3")
        {
            Debug.Log("Saving Data at " + path3);
            string json = JsonUtility.ToJson(data3);
            Debug.Log(json);
            using StreamWriter writer = new StreamWriter(path3);
            writer.Write(json);
        }
        if (SceneManager.GetActiveScene().name == "Chapter 1.1"
        ||  SceneManager.GetActiveScene().name == "Chapter 1.2"
        ||  SceneManager.GetActiveScene().name == "Chapter 1.3")
        {
            Debug.Log("Saving Data at " + pathLvl);
            string json = JsonUtility.ToJson(dataLvl);
            Debug.Log(json);
            using StreamWriter writer = new StreamWriter(pathLvl);
            writer.Write(json);
        }
    }

    // public void ReadData()
    // {
    //     if (SceneManager.GetActiveScene().name == "Chapter 1.0")
    //     {
    //         using StreamReader reader = new StreamReader(path0);
    //         string json = reader.ReadToEnd();

    //         Data0 dat0 = JsonUtility.FromJson<Data0>(json);
    //         dat0.song0 = int.Parse(dat0.ToString());

    //         Debug.Log("Highest Score: " + dat0.song0);
    //     }
    //     if (SceneManager.GetActiveScene().name == "Song 0")
    //     {
    //         using StreamReader reader = new StreamReader(path0);
    //         string json = reader.ReadToEnd();

    //         Data0 data0 = JsonUtility.FromJson<Data0>(json);
    //         Debug.Log("Highest Score: " + data0.ToString());
    //     }
    //     if (SceneManager.GetActiveScene().name == "Song 1")
    //     {
    //         using StreamReader reader = new StreamReader(path1);
    //         string json = reader.ReadToEnd();

    //         Data1 data1 = JsonUtility.FromJson<Data1>(json);
    //         Debug.Log("Highest Score: " + data1.ToString());
    //     }
    //     if (SceneManager.GetActiveScene().name == "Song 2")
    //     {
    //         using StreamReader reader = new StreamReader(path2);
    //         string json = reader.ReadToEnd();

    //         Data2 data2 = JsonUtility.FromJson<Data2>(json);
    //         Debug.Log("Highest Score: " + data2.ToString());
    //     }

    //     if (SceneManager.GetActiveScene().name == "Song 3")
    //     {
    //         using StreamReader reader = new StreamReader(path3);
    //         string json = reader.ReadToEnd();

    //         Data3 data3 = JsonUtility.FromJson<Data3>(json);
    //         Debug.Log("Highest Score: " + data3.ToString());
    //     }
    //     if (SceneManager.GetActiveScene().name == "Chapter 1.1"
    //     ||  SceneManager.GetActiveScene().name == "Chapter 1.2" 
    //     ||  SceneManager.GetActiveScene().name == "Chapter 1.3")
    //     {
    //         using StreamReader reader = new StreamReader(path4);
    //         string json = reader.ReadToEnd();

    //         Data4 data4 = JsonUtility.FromJson<Data4>(json);
    //         Debug.Log(data4.ToString());
    //     }
    // }

}
