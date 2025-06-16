using UnityEngine;
using System.Collections;

public class DialogueRemote : MonoBehaviour
{
    private CameraFollow cameraF;
    GameObject[] speakers;
    PlayerData data;
    void Start()
    {
        speakers = GameObject.FindGameObjectsWithTag("Dialogue");
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        if (data.GetEnteredVilage()){
            foreach (GameObject i in speakers){
                Dialogue dialogue = i.GetComponent<Dialogue>();
                if (dialogue.getName() == "Sue"){
                    i.transform.parent.gameObject.SetActive(false);
                }
                gameObject.SetActive(false);
            }
        }
        cameraF = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (!data.GetEnteredVilage()){
            if (collision.gameObject.tag == "PlayerBody"){
                data.SetEnteredVilage(true);
                foreach (GameObject i in speakers){
                    Dialogue dialogue = i.GetComponent<Dialogue>();
                    if(dialogue.getName() == "Sue"){
                        StartCoroutine(disable(i.transform.parent.gameObject,dialogue));
                    }
                }
            }
        }
        
    }
    private IEnumerator disable(GameObject speaker, Dialogue dialogue)
    {
        cameraF.SetFolowTarget(speaker);
        cameraF.SetFolowPlayer(false);
        cameraF.SetSmooth(3);
        yield return new WaitForSeconds(1f);
        dialogue.TriggerTalk();
        yield return new WaitForSeconds(0.001f);
        transform.gameObject.SetActive(false);
        cameraF.SetFolowPlayer(true);
        cameraF.SetFolowTarget(null);
        speaker.SetActive(false);
        yield return new WaitForSeconds(1f);
        cameraF.SetSmooth(3);
    }
}
