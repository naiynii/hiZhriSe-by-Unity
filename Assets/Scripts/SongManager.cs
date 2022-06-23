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
    // public static SongManager Instance;
    // public AudioSource audioSource;
    // public float songDelayInSeconds;
    // public double marginOfError; // in seconds
    // public string fileLocation;
    public Lane lane;
    public static float noteTime;
    public float noteSpawnY;
    public float noteSpawnX;
    public static float noteTapY = 0;
    public static float noteTapX = 0;
    public float noteDespawnY { get { return noteTapY - noteSpawnY; } }
    public float noteDespawnX { get { return noteTapX - noteSpawnX; } }
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Chapter 1.0" || SceneManager.GetActiveScene().name == "Chapter 1.1" 
         || SceneManager.GetActiveScene().name == "Chapter 1.2" || SceneManager.GetActiveScene().name == "Chapter 1.3")
        {
            Difficulty.Normal();
        }
    }

    // private void ReadFromFile()
    // {
    //     midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
    //     // GetDataFromMidi();

    //     Invoke(nameof(GetDataFromMidi), 1.0f);
    // }
    // public void GetDataFromMidi()
    // {
    //     var notes = midiFile.GetNotes();
    //     var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
    //     notes.CopyTo(array, 0);

    //     lane.SetTimeStamps(array);

    //     // Invoke(nameof(StartSong), songDelayInSeconds);
    // }
    // public void StartSong()
    // {
    //     audioSource.Play();
    // }
    // public double GetAudioSourceTime()
    // {
    //     return (double)audioSource.timeSamples / audioSource.clip.frequency;
    // }

    void Update()
    {
        
    }
}
