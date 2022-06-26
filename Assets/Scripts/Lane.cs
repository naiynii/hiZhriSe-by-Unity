using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public PositionNote positionNote;
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    // public Melanchall.DryWetMidi.MusicTheory.Chord chordRestriction;
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
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongsManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (SongsManager.Instance.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.noteTime)
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
            double marginOfError = 0.067;
            double audioTime = SongsManager.Instance.GetAudioSourceTime();

            if (Input.GetKeyDown(input1)  && PauseMenu.GameIsPause == false || Input.GetKeyDown(input2) && PauseMenu.GameIsPause == false)
            {
                if (Math.Abs(audioTime - timeStamp) <= (marginOfError / 2) && Math.Abs(audioTime - timeStamp) >= 0)
                {
                    Perfect();
                    Debug.Log($"Perfecto hit!!, +1 Combo, +2 HP");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                    //  on note {inputIndex + 1}
                }
                else if (Math.Abs(audioTime - timeStamp) <= marginOfError && Math.Abs(audioTime - timeStamp) > (marginOfError / 2))
                {
                    Nice();
                    Debug.Log($"Naisu hit!, +1 Combo, +1 HP");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else
                {
                    Air();
                    Debug.Log($"Air hit?, with {Math.Abs((float)Math.Round((audioTime - timeStamp) * 1000f) / 1000f)} seconds delay, Combo cleared, -1 HP");
                }
            }

            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                Debug.Log($"Misz!?, Combo cleared, -3 HP");
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
