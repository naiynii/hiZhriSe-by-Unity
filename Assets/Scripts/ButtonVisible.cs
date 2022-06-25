using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVisible : MonoBehaviour
{
    public Button Button2, Button3;
    DataLvl levels;
    void Start()
    {
        SaveManager.SetPaths();
        using StreamReader reader = new StreamReader(SaveManager.pathLvl);
        string json = reader.ReadToEnd();
        reader.Dispose();
        levels = JsonUtility.FromJson<DataLvl>(json);
    }
    void Update()
    {
        try
        {
            if (levels.level > 1)
            {
                Button2.enabled = true;
                Button3.enabled = false;
            }
            else if (levels.level > 2)
            {
                Button2.enabled = true;
                Button3.enabled = true;
            }
        }
        catch
        {
            Button2.enabled = false;
            Button3.enabled = false;
        }

    }
}
