using UnityEngine;
using System.Collections;

public class VineSweep : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float startAngle = 90;
    private int degrees = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnEnable()
    {
        StartCoroutine(Swing());
    }

    IEnumerator Swing() {
        degrees = 0;
        while (degrees <= 360) {
            yield return new WaitForSeconds(1 / speed);
            transform.parent.rotation = Quaternion.Euler(0, 0, degrees + startAngle);
            degrees++;
        }
        degrees = 0;
        transform.gameObject.SetActive(false);
     }
}
