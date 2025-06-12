using UnityEngine;

public class EyeFolow : MonoBehaviour
{
    Rigidbody2D body;
    GameObject pupol;
    GameObject player;
    void Start()
    {
        body = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        pupol = transform.GetChild(0).gameObject;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (body.position - player.GetComponent<Rigidbody2D>().position).normalized;
        float degrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(degrees, Vector3.forward);
        pupol.transform.rotation = Quaternion.AngleAxis(0,Vector3.forward);
    }
}
