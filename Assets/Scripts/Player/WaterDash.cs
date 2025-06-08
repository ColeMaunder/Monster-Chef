using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterDash : MonoBehaviour
{

    private PlayerData data;
    private Rigidbody2D playerRB;
    private GameObject playerBody;
    public float waterDashSpeed = 2;
    public float minSpeed = 10;

    void Start()
    {
        playerBody = GameObject.FindWithTag("PlayerBody");
        playerRB = transform.parent.parent.gameObject.GetComponent<Rigidbody2D>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
    }
    void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Water")
        {
            Collider2D hitColider = hit.gameObject.GetComponent<TilemapCollider2D>();
            // Edit Note!!! need to check which direction the player is moving (into or out of the object) so they dont get stuck as ingredibly slow
            Vector3 playerVelocity = playerRB.linearVelocity; //Check player velocity direction
            Vector3 inDirect = (hit.transform.position - playerBody.transform.position).normalized; //which direction moving in from


            if (data.getIsDash()) // move towards leap
            {
                Physics2D.IgnoreCollision(hitColider, playerBody.GetComponent<Collider2D>());
                playerRB.linearVelocity = data.getMoveDir().normalized * waterDashSpeed;
                print("leap");
                data.setCanMove(false);
            }
        }
        if (hit.gameObject.tag == "Walls")
        {
            playerRB.linearVelocity = data.getMoveDir().normalized * -waterDashSpeed;
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Water")
        {
            Collider2D hitColider = hit.gameObject.GetComponent<TilemapCollider2D>();
            Physics2D.IgnoreCollision(hitColider, playerBody.GetComponent<Collider2D>(), false);
            playerRB.linearVelocity = Vector2.zero;
            data.setCanMove(true);
        }
    }
}
