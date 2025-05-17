using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private EnemyData data  = null;
    public int index = 0;
    public float activationDistance = 50f;
    public Rigidbody2D spawnerPosition;
    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(data.PlayerDistance(spawnerPosition) <= activationDistance){
            spawnEmeny(index);
            this.gameObject.SetActive(false);
        }
    }
    private void spawnEmeny(int index){
        Instantiate(data.getEnemyList(index), transform.position, Quaternion.identity);
    }
}
