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
        if (Input.GetKey(KeyCode.LeftArrow) && PauseMenu.GameIsPause == false
         || Input.GetKey(KeyCode.A) && PauseMenu.GameIsPause == false)
        {
            anim.SetTrigger("lefting");
        }
        if (Input.GetKey(KeyCode.RightArrow) && PauseMenu.GameIsPause == false
         || Input.GetKey(KeyCode.D) && PauseMenu.GameIsPause == false)
        {
            anim.SetTrigger("righting");
        }
        if (Input.GetKey(KeyCode.UpArrow) && PauseMenu.GameIsPause == false
         || Input.GetKey(KeyCode.W) && PauseMenu.GameIsPause == false)
        {
            anim.SetTrigger("upping");
        }
        if (Input.GetKey(KeyCode.DownArrow) && PauseMenu.GameIsPause == false
         || Input.GetKey(KeyCode.S) && PauseMenu.GameIsPause == false)
        {
            anim.SetTrigger("downing");
        }
    }
}
