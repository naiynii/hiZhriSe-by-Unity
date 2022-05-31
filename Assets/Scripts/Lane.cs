﻿using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public PositionNote positionNote;
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    int spawnIndex = 0;
    int inputIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongsManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (SongsManager.Instance.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongsManager.Instance.songsManager[positionNote].noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                note.GetComponent<Note>().positionNote = positionNote;
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongsManager.Instance.songsManager[positionNote].marginOfError;
            double audioTime = SongsManager.Instance.GetAudioSourceTime() - (SongsManager.Instance.songsManager[positionNote].inputDelayInMilliseconds / 1000.0);

            if (Input.GetKeyDown(input))
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    // Hit();
                    // print($"Hit on {inputIndex} note");
                    // Destroy(notes[inputIndex].gameObject);
                    // inputIndex++;
                    if (Math.Abs(audioTime - timeStamp) <= 0.033 && Math.Abs(audioTime - timeStamp) > 0)
                    {
                        Perfect();
                        print($"Perfecto!! hit on note {inputIndex}");
                        Destroy(notes[inputIndex].gameObject);
                        inputIndex++;
                    }
                    if (Math.Abs(audioTime - timeStamp) <= 0.067 && Math.Abs(audioTime - timeStamp) > 0.033)
                    {
                        Nice();
                        print($"Naisu! hit on note {inputIndex}");
                        Destroy(notes[inputIndex].gameObject);
                        inputIndex++;
                    }
                }
                else
                {
                    Air();
                    print($"Air? hit on note {inputIndex} with {Math.Abs(audioTime - timeStamp)} delay");
                    print($"Combo cleared");
                }
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                print($"Misz!? on note {inputIndex}");
                inputIndex++;
            }
        }       
    
    }
    private void Perfect()
    {
        ScoreManager.Perfecto();
    }
    private void Nice()
    {
        ScoreManager.Naisu();
    }
    private void Air()
    {
        ScoreManager.Air();
    }
    private void Miss()
    {
        ScoreManager.Misz();
    }
    
}
