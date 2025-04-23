using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform target;
     public float smooth = 0.5f;
     public Vector3 offset = new Vector3(0f, 0f, -10f);
     private Vector3 camvelocity = Vector3.zero;




     // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
     {
        target = GameObject.FindWithTag("Player").transform;
     }

     // Update is called once per frame
     void Update()
     {
         Vector3 targetPosition = target.transform.position + new Vector3(0f, 0f, -10f);
         transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camvelocity, smooth);

     }

   



}
