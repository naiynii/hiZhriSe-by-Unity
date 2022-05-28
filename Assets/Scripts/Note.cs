using System.Collections;
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
        timeInstantiated = SongsManager.Instance.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongsManager.Instance.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongsManager.Instance.songsManager[positionNote].noteTime * 2));

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            if (y)
            {
                transform.localPosition = Vector3.Lerp(Vector3.up * SongsManager.Instance.songsManager[positionNote].noteSpawnY, Vector3.up * SongsManager.Instance.songsManager[positionNote].noteDespawnY, t);
                GetComponent<SpriteRenderer>().enabled = true;
            }
            if (x)
            {
                transform.localPosition = Vector3.Lerp(Vector3.right * SongsManager.Instance.songsManager[positionNote].noteSpawnX, Vector3.right * SongsManager.Instance.songsManager[positionNote].noteDespawnX, t);
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
