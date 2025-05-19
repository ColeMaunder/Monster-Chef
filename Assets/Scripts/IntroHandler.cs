using UnityEngine;
using System.Collections;

public class IntroHandler : MonoBehaviour
{

    public GameObject buttonGo;
    void Start()
    {
        StartCoroutine(button());
    }

    IEnumerator button() {
        yield return new WaitForSeconds(11f);
        buttonGo.SetActive(true);
    }
}
