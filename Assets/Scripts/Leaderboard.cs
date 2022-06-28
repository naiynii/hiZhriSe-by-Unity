using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public TMPro.TextMeshProUGUI song0, song1, song2, song3;

    void Start()
    {
        SaveManager.SetPaths();
        Song0(); Song1(); Song2(); Song3();
    }

    private void Song0()
    {
        try
        {
        using StreamReader reader = new StreamReader(SaveManager.path0);
        string json = reader.ReadToEnd();
        reader.Dispose();

        Data0 high = JsonUtility.FromJson<Data0>(json);
        song0.text = high.song0.ToString();
        }
        catch {}
    }

    private void Song1()
    {
        try
        {
        using StreamReader reader = new StreamReader(SaveManager.path1);
        string json = reader.ReadToEnd();
        reader.Dispose();

        Data1 high = JsonUtility.FromJson<Data1>(json);
        song1.text = high.song1.ToString();
        }
        catch {}
    }
    
    private void Song2()
    {
        try
        {
        using StreamReader reader = new StreamReader(SaveManager.path2);
        string json = reader.ReadToEnd();
        reader.Dispose();

        Data2 high = JsonUtility.FromJson<Data2>(json);
        song2.text = high.song2.ToString();
        }
        catch {}
    }

    private void Song3()
    {
        try
        {
        using StreamReader reader = new StreamReader(SaveManager.path3);
        string json = reader.ReadToEnd();
        reader.Dispose();

        Data3 high = JsonUtility.FromJson<Data3>(json);
        song3.text = high.song3.ToString();
        }
        catch {}
    }

}
