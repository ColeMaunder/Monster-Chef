using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    private EnemyData data  = null;
    public Rigidbody2D enmenyBody;

    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
    }

    void Update()
    {
        if(data.GetCanMove()){
            float distance = data.PlayerDistance(enmenyBody);
            if (distance < data.GetAgroRaing()){
                if (distance > data.GetFavoredDistance()){
                    enmenyBody.transform.position += transform.up * data.GetEnemySpeed() * Time.deltaTime;
                }else{
                    enmenyBody.transform.position -= transform.up * data.GetEnemySpeed() * Time.deltaTime;
                }
            }
        }else{
            print ("movment stopped");
        }
        
        
    }
}
