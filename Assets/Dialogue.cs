using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private List<int> heardDialog = new List<int>();
    private GameObject dialoguePanel;
    private TMP_Text dialogueText;
    private TMP_Text nameTXT;
    private GameObject nextButton;
    private Image face;
    [SerializeField] Sprite [] faceNPC;
    [SerializeField] string nameNPC;
    public string[] dialogueLines;
    [SerializeField] public int[] faceIDs;
    [SerializeField] GameObject witingIcon;
    private int index;
    public float typeSpeedIn = 0.03f;
    [SerializeField] private float typeSpeed;
    public bool inRainge;
    public bool wating = true;
    bool running = false;
    private CameraFollow cameraF;
    bool forceDialog = false;
    void Start()
    {
        typeSpeed = typeSpeedIn;
        dialoguePanel = GameObject.FindWithTag("UI").transform.GetChild(6).gameObject;
        face = dialoguePanel.transform.GetChild(0).gameObject.GetComponent<Image>();
        nameTXT = dialoguePanel.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        dialogueText = dialoguePanel.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
        nextButton = dialoguePanel.transform.GetChild(3).gameObject;
        cameraF = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    IEnumerator Typing()
    {
        dialogueText.text = "";
        face.sprite = faceNPC[faceIDs[index]];
        foreach (char letter in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typeSpeed);
        }
    }

    public void NextLine(){
        if (running) {
            typeSpeed = typeSpeedIn;
            nextButton.SetActive(false);

            if (index < dialogueLines.Length - 1){
                face.sprite = faceNPC[0];
                nameTXT.text = nameNPC;
                index++;
                dialogueText.text = "";
                StopCoroutine(Typing());
                StartCoroutine(Typing());
            } else {
                forceDialog = false;
                index = 0;
                running = false;
                Time.timeScale = 1f;
                dialoguePanel.SetActive(false);
            }
        }
    }
    public void TriggerTalk(){
        forceDialog = true;
        inRainge = true;
        DialogueData data = GameObject.FindWithTag("PlayerData").GetComponent<DialogueData>();
        setNewDialogue(1,data.GetDialog(0,2),data.GetFaceID(0,2));
        typeSpeed = typeSpeedIn;
        running = true;
        cameraF.SetFolowPlayer(false);
        cameraF.SetFolowTarget(transform.gameObject);
        Time.timeScale = 0;
        wating = false;
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());
    }
    void Update()
    {
        if(wating){
            witingIcon.SetActive(true);
        }else{
            witingIcon.SetActive(false);
        }
        if (inRainge){
            if (Input.GetKeyDown(KeyCode.E)){
                if (!running){
                    typeSpeed = typeSpeedIn;
                    running = true;
                    cameraF.SetFolowPlayer(false);
                    cameraF.SetFolowTarget(transform.gameObject);
                    Time.timeScale = 0;
                    wating = false;
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing());
                } else {
                    if (nextButton.activeSelf) {
                        NextLine();
                    } else {
                        typeSpeed = 0.001f;
                    }
                }

            }
        }
        if (dialogueText.text == dialogueLines[index]){
            nextButton.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
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
    public void setNewDialogue(int id,string [] newDialogue, int[] faceID){
        if(!forceDialog){
           if(!heardDialog.Contains(id)){
                heardDialog.Add(id);
                wating = true;
                dialogueLines = newDialogue;
                faceIDs = faceID;
            } 
        }
        
    }
    public string getName(){
        return nameNPC;
    }
}