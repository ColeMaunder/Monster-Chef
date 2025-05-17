using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    private bool canDash = true;
    private bool keyHold = false;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private float currentSpeed;
    private Animator Animator;
    private PlayerData data;
    public GameObject particleOBJ;
    private ParticleSystem ps;
    private ParticleSystemForceField psff;
    private CircleCollider2D rb2D;
    public PlayerMovment(){}
    private AudioSource walkSound;
    void Start()
    {
        Animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        ps = particleOBJ.GetComponent<ParticleSystem>();
        psff = particleOBJ.GetComponent<ParticleSystemForceField>();
        rb2D = particleOBJ.GetComponent<CircleCollider2D>();
        currentSpeed = data.GetMoveSpeed();
        var main = ps.main;
        main.duration = data.GetDashTime();
        walkSound = gameObject.GetComponent<AudioSource>();
        walkSound.clip = data.getWalkSound();
    }

    

    

    //Dash Function (use seconds instead of frames)
    IEnumerator Dash ()
    {
        data.SetCooldownTimer(data.GetDashCool());
        canDash = false;
        data.setIsDash(true);
        rb2D.enabled = false;
        ps.transform.rotation = Quaternion.Euler(0, 0, - Mathf.Rad2Deg * Mathf.Atan2(moveDir.y, moveDir.x));
        ps.Play();
        print("Is Dashing");
        data.playDashSound();
        currentSpeed = data.GetMoveSpeed() * data.GetDashMod();
        
        yield return new WaitForSeconds(data.GetDashTime());
        data.setIsDash(false);
        currentSpeed = data.GetMoveSpeed();
        print("Dash on cooldown");
        
        yield return new WaitForSeconds(data.GetDashCool() -0.5f);
        rb2D.enabled = true;
        psff.enabled = true;

        yield return new WaitForSeconds(0.5f);
        psff.enabled = false;
        canDash = true;
        ps.Stop();
        print("Dash off cooldown");
    }

    void FixedUpdate()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Check speed (dash or not)
        if (!data.getIsDash() && Input.GetKey(KeyCode.Space) && canDash && !keyHold) {
                StartCoroutine(Dash());
                keyHold = true;
        }else if(!Input.GetKey(KeyCode.Space)){
            keyHold = false;
        }

        // Move with velocity when pressing movement keys
        if (Input.GetKey(KeyCode.W) /*|| Input.GetKey(KeyCode.UpArrow)*/ || Input.GetKey(KeyCode.S) /*|| Input.GetKey(KeyCode.DownArrow)*/ || Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/ || Input.GetKey(KeyCode.D) /*s|| Input.GetKey(KeyCode.RightArrow)*/)
        {
            Animator.SetBool("walking", true);
            walkSound.Play();
            rb.linearVelocity = moveDir * currentSpeed;
        }
        else
        {
            Animator.SetBool("walking", false);
            walkSound.Stop();
            rb.linearVelocity = Vector2.zero;
        }
    }
}
