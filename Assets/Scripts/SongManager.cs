using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;

public class SongManager : MonoBehaviour
{
    // public static SongManager Instance;
    // public AudioSource audioSource;
    public Lane lane;
    // public float songDelayInSeconds;
    public double marginOfError; // in seconds

    public int inputDelayInMilliseconds;
    
    // public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public float noteSpawnX;
    public float noteTapY;
    public float noteTapX;
    public float noteDespawnY { get { return noteTapY - (noteSpawnY - noteTapY); } }
    public float noteDespawnX { get { return noteTapX - (noteSpawnX - noteTapX); } }

    public MidiFile midiFile;
    // Start is called before the first frame update
    // void Start()
    // {
    //     ReadFromFile();
    // }

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
