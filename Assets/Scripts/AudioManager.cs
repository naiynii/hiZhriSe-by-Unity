using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public enum PositionNote { Up, Down, Left, Right }
public class AudioManager : MonoBehaviour
{
    public string fileLocation;
    public static MidiFile midiFile;
    public AudioSource audioSource;
    public Dictionary<PositionNote, SongManager> audioManager = new Dictionary<PositionNote, SongManager>();
    public static AudioManager Instance;
    public static float songsDuration;
    public static string songsName;

    void Start()
    {
        Instance = this;
        audioManager.Add(PositionNote.Up, transform.GetChild(0).GetComponent<SongManager>());
        audioManager.Add(PositionNote.Down, transform.GetChild(1).GetComponent<SongManager>());
        audioManager.Add(PositionNote.Left, transform.GetChild(2).GetComponent<SongManager>());
        audioManager.Add(PositionNote.Right, transform.GetChild(3).GetComponent<SongManager>());

        ReadFromFile();
        
        songsDuration = (float)Math.Round(audioSource.clip.length * 1000f) / 1000f;
        songsName = audioSource.clip.ToString().Replace(" (UnityEngine.AudioClip)", "");
        Debug.Log("Now playing: " + songsName + "; Song duration: " + songsDuration + " seconds");
    }

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }

    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var songManager in audioManager)
        {
            songManager.Value.lane.SetTimeStamps(array);
        }

        audioSource.Play();
    }

    public double GetAudioSourceTime()
    {
        return (double)audioSource.timeSamples / audioSource.clip.frequency;
    }
    
}
