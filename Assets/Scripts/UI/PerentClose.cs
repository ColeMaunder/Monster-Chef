using UnityEngine;

public class PerentClose : MonoBehaviour
{
    [SerializeField] int[] watching = {0};
    [SerializeField] bool isPauseScreen = false;
    [SerializeField] bool hasMusic = false;
    void Update()
    {
        if(!isPauseScreen){
            if (Input.GetKey(KeyCode.Escape)){
                doClose();
            }
        }else{
                doClose();
        }
    }
    private void doClose(){
        if (hasMusic){
            GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>().FaidBetweenWorldSound
                (GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>().GetSceneMusic(), 1, 10, 0);
        }
        bool canClose = true;
        foreach (int i in watching)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                canClose = false;
            }
        }
        if(canClose){
            gameObject.SetActive(false);
                Time.timeScale = 1f;
        }
    }
    
}
