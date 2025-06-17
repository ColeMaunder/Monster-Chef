using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject BlockBox;
    CameraFollow camra;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody")
        {
            transform.parent.gameObject.GetComponent<FazeManager>().StartFight();
            gameObject.SetActive(false);
            animator.SetBool("block", true);
            BlockBox.SetActive(true);
            camra = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
            camra.SetCamraMove(false);
            camra.transform.position =  new Vector3( 68, -3, -10);
        }
    }
    void Update()
    {
        if(!GameObject.FindWithTag("Player").GetComponent<Player>().GetPlayerAlive()){
            gameObject.SetActive(true);
            animator.SetBool("block",false);
            BlockBox.SetActive(false);
            camra.SetCamraMove(true);
        }
    }
}
