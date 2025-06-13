using UnityEngine;

public class FolowerContact : MonoBehaviour
{
    private bool contact = false;
    void OnTriggerStay2D(Collider2D collision)
    {
        contact = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        contact = false;
    }
    public bool GetContact()
    {
        return contact;
    }
}
