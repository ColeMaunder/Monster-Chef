using UnityEngine;

public class FolowerMovment : MonoBehaviour
{
    private EnemyData data = null;
    public Rigidbody2D enmenyBody;
    [SerializeField] float speed;

    float random;
    float spinRandom;

    void Start()
    {
        enmenyBody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
    }
    void OnEnable()
    {
        random = Random.Range(2.5f, 10f);
        spinRandom = Random.Range(-20f, 20f);
    }

    void Update()
    {
        float distance = data.PlayerDistance(enmenyBody);
        if (distance > random)
        {
            enmenyBody.transform.position += transform.up * speed * Time.deltaTime;
            enmenyBody.transform.position += transform.right * spinRandom * Time.deltaTime;
        }
        else
        {
            enmenyBody.transform.position -= transform.up * speed * Time.deltaTime;
            enmenyBody.transform.position += transform.right * spinRandom * Time.deltaTime;
        }
    }
}
