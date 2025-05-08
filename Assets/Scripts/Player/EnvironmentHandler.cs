using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    
    PlayerMovment player;
    public Rigidbody2D playerRB;
    public float dotCan = 0f;
    public float dotCant = 0.7f;
    public float mudMod = 0.5f;
    public float mudDrag = 30f;
    public float waterStop = 3000f;
    public GameObject Player;
    public GameObject startBlock;
   
    void Start()
    {
        player = this.GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Boundary")
        {
            print("Hit Boundary");
        }
    }


    void OnTriggerEnter2D(Collider2D trigger)
    {
        //Mud
        if (trigger.gameObject.name == "Mud")
        {
            print("in Mud");
            playerRB.linearDamping = mudDrag;

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
            playerRB.linearDamping = 0;
        }

        //Null
        if (trigger.gameObject == null)
        {
            print("Null");
            playerRB.linearDamping = 0;
        }

        //Water
        /* if (trigger.gameObject.name == "Water")
         {
             if (currentSpeed == moveSpeed)
             {
                 print("Can't cross");
                 playerRB.linearDamping = waterStop;
             }
             if(currentSpeed == dashSpeed)
             {
                 print("leap");
                 playerplayerRB.linearDamping = 0;
             }

         }*/
    }

   void OnTriggerStay2D(Collider2D inside)
    {
        if (inside.gameObject.name == "Water")
        {
            // Edit Note!!! need to check which direction the player is moving (into or out of the object) so they dont get stuck as ingredibly slow
            
            Vector3 playerVelocity = playerRB.linearVelocity; //Check player velocity direction
            Vector3 inDirect = (inside.transform.position - Player.transform.position).normalized; //which direction moving in from
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

            if (!player.GetIsDash() && dot > dotCant) //move towards cant cross
            {
                print("Can't cross");
                playerRB.linearDamping = waterStop;
            }
            if (player.GetIsDash() && dot > dotCant) // move towards leap
            {
                print("leap");
                playerRB.linearDamping = 0;
            }

            if (!player.GetIsDash() && dot <= dotCan)
            {
                print("Walk Away");
                playerRB.linearDamping = 0;
            }
            if (player.GetIsDash() && dot <= dotCan)
            {
                print("Dash Away");
                playerRB.linearDamping = 0;
            }
        

        }
        
    }
}
