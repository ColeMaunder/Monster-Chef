using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;

public class FazeManager : MonoBehaviour
{
    [SerializeField] GameObject boss;
    private Animator animator;
    bool hasLivingEnemys = false;
    bool victory = false;
    void Start()
    {
        animator = boss.GetComponent<Animator>();
        StartCoroutine(FazeChanger ());
    }
    void Update()
    {
        if (boss.IsDestroyed() && !victory)
        {
            StartCoroutine(Vicory());
            victory = true;
            StopCoroutine(FazeChanger());
        }
        GameObject[] livingEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        if(livingEnemys.Length <= 0){
            hasLivingEnemys = false;
        }else{
            hasLivingEnemys = true;
        }
    }

    IEnumerator FazeChanger (){
        while (!victory){
        animator.SetBool("Closed", true);
        SpawnWave(0);
        while (hasLivingEnemys){
            yield return new WaitForSeconds(0.1f);
        }
        animator.SetBool("Closed", false); 
        SpawnWave(1);
        yield return new WaitForSeconds(5f);
        }
        
    }
     IEnumerator Vicory (){
        yield return new WaitForSeconds(1);
    }

    private void SpawnWave(int num){
        GameObject [] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject i in spawners){
            i.GetComponent<Spawner>().ActiveGroup(num);
        }
    }
}
