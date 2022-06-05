using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject pic1, pic2, pic3;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
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

        if (SceneManager.GetActiveScene().name == "Dialog 1.1")
        {
            if (textComponent.text == lines[0])
            {
                pic1.SetActive(true);
                pic2.SetActive(false);
                pic3.SetActive(false);
            }
            if (textComponent.text == lines[9])
            {
                pic1.SetActive(false);
                pic2.SetActive(true);
                pic3.SetActive(false);
            }
            if (textComponent.text == lines[22])
            {
                pic1.SetActive(false);
                pic2.SetActive(false);
                pic3.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene().name == "Dialog 1.1")
        {

        }
        if (SceneManager.GetActiveScene().name == "Dialog 1.2")
        {

        }
        if (SceneManager.GetActiveScene().name == "Dialog 1.3")
        {

        }
    }

}


