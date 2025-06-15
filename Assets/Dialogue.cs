using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogueLines;
    private int index;
    public GameObject nextButton;
    public float typeSpeed;
    public bool inRainge;

    IEnumerator Typing()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextLine()
    {
        nextButton.SetActive(false);

        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StopCoroutine(Typing());
            StartCoroutine(Typing());
        }
        else
        {
            index = 0;
        }
    }

    void Update()
    {
        if (inRainge)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        else
        {
            dialoguePanel.SetActive(false);
            StopCoroutine(Typing());
            index = 0;
        }
        if (dialogueText.text == dialogueLines[index])
        {
            nextButton.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody")
        {
            print("player in");
            inRainge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody")
        {
            inRainge = false;
        }
    }
}