using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static void ShortVer()
    {
        SongsManager.fileLocation = "0.0.mid";
    }
    public static void PlayGames()
    {
        SongsManager.fileLocation = "1.0.mid";
    }
    public static void MeetCafe()
    {
        SongsManager.fileLocation = "1.1.mid";
    }
    public static void NavyBlue()
    {
        SongsManager.fileLocation = "1.2.mid";
    }
    public static void Lull()
    {
        SongsManager.fileLocation = "1.3.mid";
    }
    public static void ForthSong()
    {
        SongsManager.fileLocation = "1.4.mid";
    }
}
