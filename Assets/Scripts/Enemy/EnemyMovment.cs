using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    private EnemyData data  = null;
    public Rigidbody2D enmenyBody;
    EnemyLocalData localData;

    void Start()
    {
        enmenyBody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        localData =  transform.parent.gameObject.GetComponent<EnemyLocalData>();
    }

    void Update()
    {
        if(localData.getCanMove()){
            float distance = data.PlayerDistance(enmenyBody);
            if (distance < data.getAgroRaing(localData.getEnemyIndex())){
                if (distance > data.getFavoredDistance(localData.getEnemyIndex())){
                    enmenyBody.transform.position += transform.up * data.getEnemySpeed(localData.getEnemyIndex()) * Time.deltaTime;
                }else{
                    enmenyBody.transform.position -= transform.up * data.getEnemySpeed(localData.getEnemyIndex()) * Time.deltaTime;
                }
            }
        }else{
            print ("movment stopped");
        }
        
        
    }
}
