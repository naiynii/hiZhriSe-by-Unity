using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public PositionNote positionNote;
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input1, input2;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    int spawnIndex = 0, inputIndex = 0;

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, AudioManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (AudioManager.Instance.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.noteTime)
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
            double audioTime = AudioManager.Instance.GetAudioSourceTime();
            double timeStamp = timeStamps[inputIndex];
            float marginOfError = 0.080f;
            double timeDiff = audioTime - timeStamp;
            var delay = ((float)Math.Round((timeDiff) * 1000f) / 1000f);

            if (Input.GetKeyDown(input1) && PauseMenu.gameIsPause == false && GameOver.gameIsOver == false
             || Input.GetKeyDown(input2) && PauseMenu.gameIsPause == false && GameOver.gameIsOver == false)
            {
                if (Math.Abs(timeDiff) <= marginOfError / 2)
                {
                    Perfect();
                    Debug.Log($"Perfecto hit!!: combo +1, hp +2, delay " + delay + " seconds");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else if (Math.Abs(timeDiff) <= marginOfError)
                {
                    Nice();
                    Debug.Log($"Naisu hit!: combo +1, hp +1, delay " + delay + " seconds");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else
                {
                    Air();
                    Debug.Log($"Air hit: combo cleared, hp -1, delay "+ delay + " seconds");
                }
            }
            if (timeDiff > marginOfError)
            {
                Miss();
                Debug.Log($"Misz!?: combo cleared, hp -3");
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
