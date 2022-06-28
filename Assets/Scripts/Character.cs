using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OnButtonInput();
    }

    private void OnButtonInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && PauseMenu.gameIsPause == false
         || Input.GetKey(KeyCode.A) && PauseMenu.gameIsPause == false)
        {
            anim.SetTrigger("lefting");
        }
        if (Input.GetKey(KeyCode.RightArrow) && PauseMenu.gameIsPause == false
         || Input.GetKey(KeyCode.D) && PauseMenu.gameIsPause == false)
        {
            anim.SetTrigger("righting");
        }
        if (Input.GetKey(KeyCode.UpArrow) && PauseMenu.gameIsPause == false
         || Input.GetKey(KeyCode.W) && PauseMenu.gameIsPause == false)
        {
            anim.SetTrigger("upping");
        }
        if (Input.GetKey(KeyCode.DownArrow) && PauseMenu.gameIsPause == false
         || Input.GetKey(KeyCode.S) && PauseMenu.gameIsPause == false)
        {
            anim.SetTrigger("downing");
        }
    }
}
