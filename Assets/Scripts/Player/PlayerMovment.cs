using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    private bool isDash = false;
    private bool canDash = true;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private float currentSpeed;
    
    private Animator Animator;
    private PlayerData data;

    public PlayerMovment(){}
    void Start()
    {
        Animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
    }

    public bool GetIsDash(){
        return isDash;
    }

    

    //Dash Function (use seconds instead of frames)
    IEnumerator Dash ()
    {
        isDash = true;
        canDash = false;

        print("Is Dashing");
        currentSpeed = data.GetMoveSpeed() * data.GetDashMod();
        yield return new WaitForSeconds(data.GetDashTime());

        isDash = false;
        print("Dash on cooldown");
        
        yield return new WaitForSeconds(data.GetDashTime());
        canDash = true;
        print("Dash off cooldown");
    }

    void FixedUpdate()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Check speed (dash or not)
        if (Input.GetKey(KeyCode.Space) && canDash && !isDash)
        {
            data.SetCooldownTimer(data.GetDashCool());
            Coroutine coroutine = StartCoroutine(Dash());
        }
        if (!isDash)
        {
            currentSpeed = data.GetMoveSpeed();
        }


        // Move with velocity when pressing movement keys
        if (Input.GetKey(KeyCode.W) /*|| Input.GetKey(KeyCode.UpArrow)*/ || Input.GetKey(KeyCode.S) /*|| Input.GetKey(KeyCode.DownArrow)*/ || Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/ || Input.GetKey(KeyCode.D) /*s|| Input.GetKey(KeyCode.RightArrow)*/)
        {
            Animator.SetBool("walking", true);
            rb.linearVelocity = moveDir * currentSpeed;
        }
        else
        {
            Animator.SetBool("walking", false);
            rb.linearVelocity = Vector2.zero;
        }
    } 
}
