using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Unity.Collections;

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
     public Vector3 defaltOffset = new Vector3(0f, 0f, -10f);
     public Vector3 offset = new Vector3(0f, 0f, -10f);
     private Vector3 camvelocity = Vector3.zero;
     private float swingTime = 0f;
     private float swingX = 0f;
     private float swingY = 0f;
     private float swingZ = 0f;
     private bool negetive = false;
    private Vector3 targetPosition;

     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
     {
        target = GameObject.FindWithTag("Player").transform;
     }
     void Update()
     {
        targetPosition =  new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camvelocity, moveSmooth());
     }
    private float moveSmooth()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0)
        {
            return smooth / distance;
        }
        return smooth;
     }
    IEnumerator Shake(){
        while (offset != defaltOffset){
            yield return new WaitForSeconds(swingTime);
            float x = swingX;
            float y = swingY;
            float z = swingZ;
            if (negetive){
                x *= -1;
                y *= -1;
                z *= -1;
                negetive = false;
            }else{
                negetive = true;
            }
            offset += new Vector3(x, y, z);
            swingX -= 1;
            swingY -= 1;
            swingZ -= 1;
        
      }
     }

     public void activateShake(float x,float y, float z, float time){
        StartCoroutine(Shake());
        swingX = Mathf.Abs(x);
        swingY = Mathf.Abs(y);
        swingZ = Mathf.Abs(z);
        negetive = false;
     }

   



}
