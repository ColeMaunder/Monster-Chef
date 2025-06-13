using UnityEngine;

public class SwapSpawner : MonoBehaviour
{

    private EnemyData data = null;
    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
    }
    private void spawnEmeny(int index, Transform where){
        Instantiate(data.getEnemyList(index),  where.position, Quaternion.identity);
    }
    public void swap(int index)
    {
        Instantiate(data.getEnemyList(index), transform.position, Quaternion.identity);
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length > 0){
            foreach (GameObject enemy in enemys){
                spawnEmeny(index, enemy.transform);
                kill(enemy);
            }
        }
    }
    private void kill(GameObject enemy)
    {
        EnemyLocalData enemyData = enemy.GetComponent<EnemyLocalData>();
        data.playDeathSound(enemyData.getEnemyIndex());
        Instantiate(data.getDropList(enemyData.getEnemyIndex()), enemy.transform.position, Quaternion.identity);
        Destroy(enemy);
    }
}
