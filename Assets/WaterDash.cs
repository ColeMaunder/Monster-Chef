using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterDash : MonoBehaviour
{
    
    private PlayerData data;
    private Rigidbody2D playerRB;
    public float dotCan = 0f;
    public float dotCant = 0.7f;
    private GameObject playerBody;
    public float waterDashSpeed = 2;

    void Start()
    {
        playerBody = GameObject.FindWithTag("PlayerBody");
        playerRB = this.GetComponent<Rigidbody2D>();
        data =  GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
    }
    void OnTriggerStay2D(Collider2D hit)
    {
        print("contact");
        if (hit.gameObject.tag == "Water")
        {
            Collider2D hitColider = hit.gameObject.GetComponent<TilemapCollider2D>();
            // Edit Note!!! need to check which direction the player is moving (into or out of the object) so they dont get stuck as ingredibly slow
            Vector3 playerVelocity = playerRB.linearVelocity; //Check player velocity direction
            Vector3 inDirect = (hit.transform.position - playerBody.transform.position).normalized; //which direction moving in from
            //float dot = Vector2.Dot(inDirect, playerVelocity.normalized);
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
            //DrawLine(player.transform.position, player.transform.position + playerVelocity.normalized, Color.green);
            //Debug.DrawLine(player.transform.position, player.transform.position + inDirect, Color.red);
            //Debug.Log("Dot:" + dot);

            if (data.getIsDash() /*&& dot > dotCant*/) // move towards leap
            {
                Physics2D.IgnoreCollision(hitColider, playerBody.GetComponent<Collider2D>());
                playerRB.linearVelocity = data.getMoveDir() * waterDashSpeed;
                print("leap");
                data.setCanMove(false);
                
            }
        }
    }
    void OnTriggerExit2D(Collider2D hit) {
        if (hit.gameObject.tag == "Water")
        {
            Collider2D hitColider = hit.gameObject.GetComponent<TilemapCollider2D>();
            Physics2D.IgnoreCollision(hitColider, playerBody.GetComponent<Collider2D>(), false);
            playerRB.linearVelocity = Vector2.zero;
            data.setCanMove(true);
        }
    }
}
