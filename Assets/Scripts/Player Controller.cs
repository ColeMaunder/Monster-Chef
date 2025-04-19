using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.ComponentModel;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 4f;
    public float dashMod = 1.5f;
    public float dashSpeed;

    public float dashTime = 2f;
    public float dashCool = 4f;
    private bool isDash = false;
    private bool canDash = true;

    public float dotCan = 0f;
    public float dotCant = 0.7f;

    public float mudMod = 0.5f;
    public float mudDrag = 30f;
    public float waterStop = 3000f;
    public GameObject Player;
    public GameObject Water;
    

    private Rigidbody2D rb;
    private Sprite mySprite;
    private SpriteRenderer sr;
    private Vector2 moveDir;
    public float currentSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        dashSpeed = moveSpeed * dashMod;
        rb.linearDamping = 0;

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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Boundary")
        {
            print("Hit Boundary");
        }

        if (collision.gameObject.name == "Water Bound")
        {
            print("Cant Swim");
        }
    }

 

    void OnTriggerEnter2D(Collider2D trigger)
    {
        //Mud
        if (trigger.gameObject.name == "Mud")
        {
            print("in Mud");
            rb.linearDamping = mudDrag;

            /*if (currentSpeed == moveSpeed)
            {
                currentSpeed = moveSpeed * mudMod;
            }

            if (currentSpeed == dashSpeed)
            {
                currentSpeed = dashSpeed * mudMod;
            }
            //use materials to do this?*/
        }
        //Grass
        if (trigger.gameObject.name == "Grass")
        {
            print("in Grass");
            rb.linearDamping = 0;
        }

        //Null
        if (trigger.gameObject == null)
        {
            print("Null");
            rb.linearDamping = 0;
        }

        //Water
       /* if (trigger.gameObject.name == "Water")
        {
            if (currentSpeed == moveSpeed)
            {
                print("Can't cross");
                rb.linearDamping = waterStop;
            }
            if(currentSpeed == dashSpeed)
            {
                print("leap");
                rb.linearDamping = 0;
            }
            
        }*/
    }

   void OnTriggerStay2D(Collider2D inside)
    {

        if (inside.gameObject.name == "Grass")
        {
            rb.linearDamping = 0;
        }

        if (inside.gameObject.name == "Water")
        {
            // Edit Note!!! need to check which direction the player is moving (into or out of the object) so they dont get stuck as ingredibly slow
            
            Vector3 playerVelocity = rb.linearVelocity; //Check player velocity direction
            Vector3 inDirect = (Water.transform.position- Player.transform.position).normalized; //which direction moving in from
            float dot = Vector2.Dot(inDirect, playerVelocity.normalized);

            /*DOT notes:
            1 = point same direction
            0 = perpendicular
            -1 = opposite direct
            */

            /*
            !!! since Water Position is based on the game objects center the player can "cheat" by moving across the sides diagonally
            Possible Fixes:
            - If Water object is less wide the player cant get the angle to get across
            - Will this change when we start using tilemaps? is each tile a square game object?
            */

            //Debug to check the direction Visually and look at dot Value - Thanks to this realised had to reverse InDirect
            Debug.DrawLine(Player.transform.position, Player.transform.position + playerVelocity.normalized, Color.green);
            Debug.DrawLine(Player.transform.position, Player.transform.position + inDirect, Color.red);
            Debug.Log("Dot:" + dot);

            if (currentSpeed == moveSpeed && dot > dotCant) //move towards cant cross
            {
                print("Can't cross");
                rb.linearDamping = waterStop;
            }

            if (currentSpeed == dashSpeed && dot > dotCant) // move towards leap
            {
                print("leap");
                rb.linearDamping = 0;
            }

            if (currentSpeed == moveSpeed && dot <= dotCan)
            {
                print("Walk Away");
                rb.linearDamping = 0;
            }
            if (currentSpeed == dashSpeed && dot <= dotCan)
            {
                print("Dash Away");
                rb.linearDamping = 0;
            }
        

        }

    }

  

    // Update is called once per frame
    void Update()
    {

    }


}
