using UnityEngine;

public class FountainActive : MonoBehaviour
{
    FountainID  id;
    PlayerData data;
    Animator animator;
    void Start()
    {
        id = transform.parent.gameObject.GetComponent<FountainID>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("active", data.CheckFountain(id.GetID()));
    }
}
