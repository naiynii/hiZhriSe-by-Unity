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
            double marginOfError = 0.067;
            double audioTime = SongsManager.Instance.GetAudioSourceTime();

            if (Input.GetKeyDown(input1) || Input.GetKeyDown(input2))
            {
                if (Math.Abs(audioTime - timeStamp) <= (marginOfError / 2) && Math.Abs(audioTime - timeStamp) >= 0)
                {
                    Perfect();
                    print($"Perfecto hit!! on note {inputIndex}, +1 Combo, +2 HP");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else if (Math.Abs(audioTime - timeStamp) <= marginOfError && Math.Abs(audioTime - timeStamp) > (marginOfError / 2))
                {
                    Nice();
                    print($"Naisu hit! on note {inputIndex}, +1 Combo, +1 HP");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else
                {
                    Air();
                    print($"Air hit? on note {inputIndex} with {Math.Abs((float)Math.Round((audioTime - timeStamp) * 1000f) / 1000f)} delay, Combo cleared, -1 HP");
                }
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                print($"Misz!? on note {inputIndex}, Combo cleared, -3 HP");
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
