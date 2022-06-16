using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject pic1, pic2, pic3, pic4, pic5;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        BgX();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if (SceneManager.GetActiveScene().name == "Dialog 1.1")
        {
            if (index >= 0 && index < 9)
            {
                Bg1();
            }
            else if (index >= 9 && index < 22)
            {
                Bg2();
            }
            else if (index >= 22 && index < 29)
            {
                Bg3();
            }
            else
            {
                BgX();
            }
        }
        if (SceneManager.GetActiveScene().name == "Dialog 1.2")
        {
            if (index >= 0 && index < 8)
            {
                Bg1();
            }
            else if (index >= 8 && index < 15 || index >= 18 && index < 24)
            {
                Bg2();
            }
            else if (index >= 15 && index < 18)
            {
                Bg3();
            }
            else if (index >= 24 && index < 31)
            {
                Bg4();
            }
            else if (index >= 31 && index < 38)
            {
                Bg4();
            }
            else
            {
                BgX();
            }
        }
        if (SceneManager.GetActiveScene().name == "Dialog 1.3")
        {

        }

    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (scene.name == "Dialog 1.1") { SceneManager.LoadScene("Chapter 1.1"); }
            if (scene.name == "Dialog 1.2") { SceneManager.LoadScene("Chapter 1.2"); }
            if (scene.name == "Dialog 1.3") { SceneManager.LoadScene("Chapter 1.3"); }
            // gameObject.SetActive(false);
        }
    }
    void Bg1()
    {
        pic1.SetActive(true);
        pic2.SetActive(false);
        pic3.SetActive(false);
        pic4.SetActive(false);
        pic5.SetActive(false);
    }
    void Bg2()
    {
        pic1.SetActive(false);
        pic2.SetActive(true);
        pic3.SetActive(false);
        pic4.SetActive(false);
        pic5.SetActive(false);
    }
    void Bg3()
    {
        pic1.SetActive(false);
        pic2.SetActive(false);
        pic3.SetActive(true);
        pic4.SetActive(false);
        pic5.SetActive(false);
    }
    void Bg4()
    {
        pic1.SetActive(false);
        pic2.SetActive(false);
        pic3.SetActive(false);
        pic4.SetActive(true);
        pic5.SetActive(false);
    }
    void Bg5()
    {
        pic1.SetActive(false);
        pic2.SetActive(false);
        pic3.SetActive(false);
        pic4.SetActive(false);
        pic5.SetActive(true);
    }
    void BgX()
    {
        pic1.SetActive(false);
        pic2.SetActive(false);
        pic3.SetActive(false);
        pic4.SetActive(false);
        pic5.SetActive(false);
    }

}


