using UnityEngine;

public class Boss : MonoBehaviour
{


    private Animator animator;
    private EnemyLocalData data;
    void Start()
    {
        data = transform.gameObject.GetComponent<EnemyLocalData>();
        animator = transform.gameObject.GetComponent<Animator>();
    }
    public void vulnrable(bool state)
    {
        animator.SetBool("closed", !state);
        data.setVulnrable(state);
    }
}
