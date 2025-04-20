using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{

    public float moveSpeed = 4f;
    public float dashMod = 1.5f;
    public float dashSpeed;
    public float dashTime = 2f;
    
    private bool isDash = false;
    private bool canDash = true;
    public float dashCool = 4f;


    public Rigidbody2D rb;
    private Vector2 moveDir;
    public float currentSpeed;

    public PlayerMovment(){}
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashSpeed = moveSpeed * dashMod;
    }

    public bool GetIsDash(){
        return isDash;
    }

    public float GetDashCool(){
        return dashCool;
    }

    //Dash Function (use seconds instead of frames)
    IEnumerator Dash ()
    {
        isDash = true;
        canDash = false;

        print("Is Dashing");
        currentSpeed = dashSpeed;
        yield return new WaitForSeconds(dashTime);

        isDash = false;
        print("Dash on cooldown");
        
        yield return new WaitForSeconds(dashCool);
        canDash = true;
        print("Dash off cooldown");
    }

    void FixedUpdate()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Check speed (dash or not)
        if (Input.GetKey(KeyCode.Space) && canDash && !isDash)
        {
            
            Coroutine coroutine = StartCoroutine(Dash());
        }
        if (!isDash)
        {
            currentSpeed = moveSpeed;
        }


        // Move with velocity when pressing movement keys
        if (Input.GetKey(KeyCode.W) /*|| Input.GetKey(KeyCode.UpArrow)*/ || Input.GetKey(KeyCode.S) /*|| Input.GetKey(KeyCode.DownArrow)*/ || Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/ || Input.GetKey(KeyCode.D) /*s|| Input.GetKey(KeyCode.RightArrow)*/)
        {
            rb.linearVelocity = moveDir * currentSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

           

        
    }
}
