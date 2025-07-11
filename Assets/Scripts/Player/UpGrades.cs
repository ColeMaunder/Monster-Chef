using Unity.VisualScripting;
using UnityEngine;

public class UpGrades : MonoBehaviour
{
    [SerializeField] float newMaxHealth = 30;
    private HealsUI heals;
    private HealsManger bar;
    RecipeData data;
    GameObject[] dialogues;
    DialogueData dialogueData;
    void Start()
    {
        dialogueData = GameObject.FindWithTag("PlayerData").GetComponent<DialogueData>();
        data = transform.GetChild(0).GetChild(0).gameObject.GetComponent<RecipeData>();
        heals = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(1).gameObject.GetComponent<HealsUI>();
        bar = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(2).gameObject.GetComponent<HealsManger>();
    }
    void Update()
    {
        dialogues = GameObject.FindGameObjectsWithTag("Dialogue");
        if (data.GetUnlockedRecipe(2)) {
            foreach (GameObject i in dialogues) {
                Dialogue dialogue = i.GetComponent<Dialogue>();
                if (dialogue.getName() == "Sue") {
                    dialogue.setNewDialogue(3, dialogueData.GetDialog(0, 4), dialogueData.GetFaceID(0, 4));
                }
                if (dialogue.getName() == "Billy"){
                    dialogue.setNewDialogue(3, dialogueData.GetDialog(1, 3), dialogueData.GetFaceID(1, 3));
                }
            }
        } else if (data.GetUnlockedRecipe(1)) {
            foreach (GameObject i in dialogues) {
                Dialogue dialogue = i.GetComponent<Dialogue>();
                if (dialogue.getName() == "Sue"){
                    dialogue.setNewDialogue(2, dialogueData.GetDialog(0, 3), dialogueData.GetFaceID(0, 3));
                }
                if (dialogue.getName() == "Billy"){
                    dialogue.setNewDialogue(2, dialogueData.GetDialog(1, 2), dialogueData.GetFaceID(1, 2));
                }
            }
        } else if (data.GetUnlockedRecipe(0)) {
            foreach (GameObject i in dialogues){
                Dialogue dialogue = i.GetComponent<Dialogue>();
                if (dialogue.getName() == "Sue"){
                    dialogue.setNewDialogue(1, dialogueData.GetDialog(0, 2), dialogueData.GetFaceID(0, 2));
                }
                if (dialogue.getName() == "Billy"){
                    dialogue.setNewDialogue(1, dialogueData.GetDialog(1, 1), dialogueData.GetFaceID(1, 1));
                }
            }
        } else {
            foreach (GameObject i in dialogues)
            {
                Dialogue dialogue = i.GetComponent<Dialogue>();
                if (!dialogue.GetForcedDialog()){
                    if (dialogue.getName() == "Sue") {
                        dialogue.setNewDialogue(0, dialogueData.GetDialog(0, 1), dialogueData.GetFaceID(0, 1));
                    }
                    if (dialogue.getName() == "Billy"){
                        dialogue.setNewDialogue(0, dialogueData.GetDialog(1, 0), dialogueData.GetFaceID(1, 0));
                    }
                }
            }

        }

        if (data.GetUnlockedRecipe(1)){
            gameObject.GetComponent<Player>().SetMaxHealth(newMaxHealth);
            GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>().UnlockFountain("30");
            bar.swapHealBar(0);
        }
        if (data.GetUnlockedRecipe(0)) {
            GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>().UnlockFountain("20");
            gameObject.GetComponent<Player>().SetMaxHeals(4);
            heals.addPotion(0);
        }
    }
}
