using UnityEngine;

public class Player : MonoBehaviour
{
    float health;
    public float maxHealth = 10f;
    int heals;
    public int maxHeals = 3;
    public float healAmount = 4f;
    PlayerInventory inventory;
    GameObject spawn;
    GameObject [] spawners;
    bool playerAlive = true;
    public GameObject deathScreen;

    public bool GetPlayerAlive(){
        return playerAlive;
    }

        void Start()
    {
        health = maxHealth;
        heals = maxHeals;
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        spawn = GameObject.FindWithTag("Respawn");
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        transform.position = spawn.transform.position;
        deathScreen.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!playerAlive){
            deathScreen.SetActive(true);
            //print ("still dead");
             if (Input.GetKeyDown(KeyCode.Return)){
                print("alive");
                Respawn();
                Reset();
                Time.timeScale = 1f;
                playerAlive = true;
            }
        }else if (Input.GetKeyDown(KeyCode.R)){
                Heal();
        }
    }
    public void damage(float damage){
        health -= damage;
        print("curent health is " + health);
        if(health <= 0){
            print("You are Dead");
            Dead();
        }
    }
    public int GetHeals(){
        return heals;
    }

    public int GetMaxHeals(){
        return maxHeals;
    }
    private void Heal(){
        if (heals> 0){
            float tempHp = health + healAmount;
            if (tempHp < maxHealth){
                health += healAmount;
            }else{
                health = maxHealth;
            }
            heals--;
            print ("your health is " + health);
        }
    print("you have " + heals + " healing items reminging");    
    }
    private void Dead(){
        print("You Died");
        playerAlive = false;
        Time.timeScale = 0f;
        inventory.DropInventory();
    }

    public void HealthFull(){
        health = maxHealth;
    }

    public void Respawn(){
        Reset();
        transform.position = spawn.transform.position;
        health = maxHealth;
        heals = maxHeals;
        Time.timeScale = 1f;
        playerAlive = true;
        deathScreen.SetActive(false);
        
    }

    public void Reset()
    {
        GameObject [] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemys){
            Destroy(enemy);
        }
        GameObject [] enemydrops = GameObject.FindGameObjectsWithTag("EnemyDrop");
        foreach(GameObject enemydrop in enemydrops){
            Destroy(enemydrop);
        }
        foreach(GameObject spawner in spawners){
            spawner.SetActive(true);
        }
        GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>().SetUltCharge(0);
    }

    public void RefillHeals(){
        heals = maxHeals;
    }
    public void RefillHealth(){
        health = maxHealth;
    }

    public float GetHealth(){
        return health;
    }
    public float GetMaxHealth(){
        return maxHealth;
    }
    public void SetMaxHealth(float healthIn){
        maxHealth = healthIn;
    }
    public void UpdateAll(){
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        spawn = GameObject.FindWithTag("Respawn");
    }
    public void WipeAll(){
        spawners = null;
        spawn = null;
    }


    
}
