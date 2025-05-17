using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public int enemyType = 0;
    private EnemyData data  = null;
    public Rigidbody2D enmenyBody;
    EnemyLocalData localData;

    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        localData =  transform.parent.gameObject.GetComponent<EnemyLocalData>();
    }

    void Update()
    {
        if(localData.getCanMove()){
            float distance = data.PlayerDistance(enmenyBody);
            if (distance < data.getAgroRaing(enemyType)){
                if (distance > data.getFavoredDistance(enemyType)){
                    enmenyBody.transform.position += transform.up * data.getEnemySpeed(enemyType) * Time.deltaTime;
                }else{
                    enmenyBody.transform.position -= transform.up * data.getEnemySpeed(enemyType) * Time.deltaTime;
                }
            }
        }else{
            print ("movment stopped");
        }
        
        
    }
}
