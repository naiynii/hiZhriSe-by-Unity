using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public static float speed = 4f;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }
    void Update()
    {
        transform.Translate(translation:Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -15.50f)
        { 
            transform.position = StartPosition;
        }
    }
}
