using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;

public class FazeManager : MonoBehaviour
{
    [SerializeField] GameObject bossOBj;
    [SerializeField] GameObject Fountain;
    Boss boss;
    [SerializeField]bool victory = false;
    GameObject[] livingEnemys;
    SwapSpawner spawner;
    void Start()
    {
        boss = bossOBj.gameObject.GetComponent<Boss>();
        spawner = transform.gameObject.GetComponent<SwapSpawner>();
    }
    void Update()
    {
        if (bossOBj.IsDestroyed() && !victory)
        {
            victory = true;
            StartCoroutine(Vicory());
            StopCoroutine(FazeChanger());
        }
        livingEnemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    IEnumerator FazeChanger (){
        while(!victory){
            boss.vulnrable(false);
            SpawnWave(0);
            livingEnemys = GameObject.FindGameObjectsWithTag("Enemy");
            print(livingEnemys.Length);
            while (livingEnemys.Length > 0)
            {
                yield return new WaitForSeconds(1f);
            }
            boss.vulnrable(true);
            SpawnWave(1);
            yield return new WaitForSeconds(5f);
            spawner.swap(3);
        }
        
        
    }
     IEnumerator Vicory (){
        Fountain.SetActive(true);
        yield return new WaitForSeconds(1);
    }

    private void SpawnWave(int num){
        GameObject [] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject i in spawners){
            i.GetComponent<Spawner>().ActiveGroup(num);
        }
    }
    public void StartFight(){
        StartCoroutine(FazeChanger());
    }
}
