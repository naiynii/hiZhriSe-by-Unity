using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnButtonInput();
    }

    private void OnButtonInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetTrigger("left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetTrigger("right");
        }
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     anim.SetTrigger("right");
        // }
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     anim.SetTrigger("right");
        // }
    }
}
