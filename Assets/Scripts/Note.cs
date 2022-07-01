﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public PositionNote positionNote;
    double timeInstantiated;
    public float assignedTime;
    public bool x, y;

    void Start()
    {
        timeInstantiated = AudioManager.Instance.GetAudioSourceTime();
    }
    
    void Update()
    {
        double timeSinceInstantiated = AudioManager.Instance.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.noteTime * 2));

        // if (t > 1)
        // {
        //     Destroy(gameObject);
        // }
        // else
        if (t <= 1)
        {
            if (y)
            {
                transform.localPosition = Vector3.Lerp(Vector3.up * AudioManager.Instance.audioManager[positionNote].noteSpawnY, Vector3.down * AudioManager.Instance.audioManager[positionNote].noteSpawnY, t);
                GetComponent<SpriteRenderer>().enabled = true;
            }
            if (x)
            {
                transform.localPosition = Vector3.Lerp(Vector3.right * AudioManager.Instance.audioManager[positionNote].noteSpawnX, Vector3.left * AudioManager.Instance.audioManager[positionNote].noteSpawnX, t);
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.tag == "Player")
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }
}
