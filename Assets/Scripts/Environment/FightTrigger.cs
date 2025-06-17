using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject BlockBox;
    [SerializeField] GameObject HealthBar;
    CameraFollow camra;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody")
        {
            HealthBar.SetActive(true);
            transform.parent.gameObject.GetComponent<FazeManager>().StartFight();
            animator.SetBool("block", true);
            BlockBox.SetActive(true);
        }
    }
    void Update()
    {
        if(!GameObject.FindWithTag("Player").GetComponent<Player>().GetPlayerAlive()){
            animator.SetBool("block",false);
            BlockBox.SetActive(false);
            camra.SetCamraMove(true);
        }
    }
}
