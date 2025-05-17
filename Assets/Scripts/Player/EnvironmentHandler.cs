using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{

    PlayerMovment playerMovment;
    private Rigidbody2D playerRB;
    public float dotCan = 0f;
    public float dotCant = 0.7f;
    public float mudMod = 0.5f;
    public float mudDrag = 30f;
    private GameObject player;
    public float waterDashSpeed = 2;

    void Start()
    {
        player = transform.parent.gameObject;
        playerRB = player.GetComponent<Rigidbody2D>();
        playerMovment = this.GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {

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
}
