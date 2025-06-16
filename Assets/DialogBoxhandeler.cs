using UnityEngine;

public class DialogBoxhandeler : MonoBehaviour
{
    GameObject[] dialogueOBjs;
    void Start()
    {
        dialogueOBjs = GameObject.FindGameObjectsWithTag("Dialogue");
    }
    public void localNextLine(){
        foreach (GameObject i in dialogueOBjs)
        {
            i.GetComponent<Dialogue>().NextLine();
        }
    }
}
