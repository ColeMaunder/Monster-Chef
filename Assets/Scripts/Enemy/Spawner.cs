using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] bool autoSpawner = true;
    [SerializeField] float activationDistance = 50f;
    [SerializeField] int spawnerGroup = 0;
    private EnemyData data = null;
    public int index = 0;
    public Rigidbody2D spawnerPosition;
    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (autoSpawner){
           if(data.PlayerDistance(spawnerPosition) <= activationDistance){
                spawnEmeny(index);
                this.gameObject.SetActive(false);
            } 
        }
        
    }
    private void spawnEmeny(int index){
        Instantiate(data.getEnemyList(index), transform.position, Quaternion.identity);
    }
    public void ActiveGroup(int group){
        if (group == spawnerGroup){
            spawnEmeny(index);
        }
    }
}
