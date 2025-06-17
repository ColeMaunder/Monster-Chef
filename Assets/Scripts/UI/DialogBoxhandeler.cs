using UnityEngine;

public class DialogBoxhandeler : MonoBehaviour
{
    GameObject[] dialogueOBjs;
    public void localNextLine(){
        dialogueOBjs = GameObject.FindGameObjectsWithTag("Dialogue");
        foreach (GameObject i in dialogueOBjs)
        {
            i.GetComponent<Dialogue>().NextLine();
        }
    }
}
