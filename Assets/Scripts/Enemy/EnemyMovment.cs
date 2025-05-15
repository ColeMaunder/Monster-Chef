using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public int enemyType = 0;
    private EnemyData data  = null;
    public Rigidbody2D enmenyBody;
    public GameObject localDataObj;
    EnemyLocalData localData;

    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        localData = localDataObj.GetComponent<EnemyLocalData>();
    }

    void Update()
    {
        if(localData.getCanMove()){
            float distance = data.PlayerDistance(enmenyBody);
            if (distance < data.GetAgroRaing(enemyType)){
                if (distance > data.GetFavoredDistance(enemyType)){
                    enmenyBody.transform.position += transform.up * data.GetEnemySpeed(enemyType) * Time.deltaTime;
                }else{
                    enmenyBody.transform.position -= transform.up * data.GetEnemySpeed(enemyType) * Time.deltaTime;
                }
            }
        }else{
            print ("movment stopped");
        }
        
        
    }
}
