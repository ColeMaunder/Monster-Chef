using UnityEngine;

public class DoNotDistroy : MonoBehaviour
{
    private static GameObject[] persistantObjects = new GameObject[3];
    public int objectID;
    void Awake(){
        if (persistantObjects[objectID] == null)
        {
            persistantObjects[objectID] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persistantObjects[objectID] != gameObject)
        {
            Destroy(gameObject);
        }
    }
}
