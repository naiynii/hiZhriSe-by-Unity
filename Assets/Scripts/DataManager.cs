using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public int song0, song1, song2, song3, level;

    public DataManager(int song0, int song1, int song2, int song3, int level)
    {
        this.song0 = song0;
        this.song1 = song1;
        this.song2 = song2;
        this.song3 = song3;
        this.level = level;
    }
    public override string ToString()
    {
        return $"{song0}, {song1}, {song2}, {song3}, {level}";
    }

}
