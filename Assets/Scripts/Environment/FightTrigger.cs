using UnityEngine;
using UnityEngine.SceneManagement;

public class FightTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject BlockBox;
    [SerializeField] GameObject HealthBar;
    
    bool fightStarted;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody"){
            if(!fightStarted){
                fightStarted = true;
                HealthBar.SetActive(true);
                transform.parent.gameObject.GetComponent<FazeManager>().StartFight();
                animator.SetBool("block", true);
                BlockBox.SetActive(true);
            }
        }
    }
    void Update()
    {
        if (!GameObject.FindWithTag("Player").GetComponent<Player>().GetPlayerAlive()){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
