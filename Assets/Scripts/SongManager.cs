using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    public Lane lane;
    public static float noteTime;
    public float noteSpawnY, noteSpawnX;
    // public float noteDespawnY { get { return -noteSpawnY; } }
    // public float noteDespawnX { get { return -noteSpawnX; } }
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Chapter 1.0" || SceneManager.GetActiveScene().name == "Chapter 1.1"
         || SceneManager.GetActiveScene().name == "Chapter 1.2" || SceneManager.GetActiveScene().name == "Chapter 1.3")
        {
            Difficulty.Normal();
        }
    }

}
