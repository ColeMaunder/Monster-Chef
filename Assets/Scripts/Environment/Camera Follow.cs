using UnityEngine;

//Reference
/*  Title: Camera Follow
    Author: bendux
    Date: 12/04/2025
    Code Version: 1.1
    Available at: https://gist.github.com/bendux/76a9b52710b63e284ce834310f8db773
 */

public class CameraFollow : MonoBehaviour
{
     private Transform target;
     public float smooth = 0.5f;
     public Vector3 offset = new Vector3(0f, 0f, -10f);
     private Vector3 camvelocity = Vector3.zero;

     // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
     {
        target = GameObject.FindWithTag("Player").transform;
     }
     void Update()
     {
         Vector3 targetPositionX =  new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) + offset;
         Vector3 targetPositionY =  new Vector3(transform.position.x, target.transform.position.y, target.transform.position.z) + offset;
         transform.position = Vector3.SmoothDamp(transform.position, targetPositionX, ref camvelocity, smooth);
         transform.position = Vector3.SmoothDamp(transform.position, targetPositionY, ref camvelocity, smooth/2);
     }

   



}
