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
    GameObject[] spawners;
    bool playerAlive = true;
    private CameraFollow cameraFollow;
    private PlayerData data;
    private MenuHandler menu;
    public bool GetPlayerAlive()
    {
        return playerAlive;
    }

    void Start()
    {
        menu = GameObject.FindWithTag("UI").GetComponent<MenuHandler>();
        health = maxHealth;
        heals = maxHeals;
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        spawn = GameObject.FindWithTag("Respawn");
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        menu.showDeathScreen(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerAlive)
        {
            menu.showDeathScreen(true);
            //print ("still dead");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                print("alive");
                Respawn();
                Reset();
                Time.timeScale = 1f;
                playerAlive = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Heal();
        }
    }
    public void damage(float damage)
    {
        health -= damage;
        data.playHurtSound();
        cameraFollow.activateShake(30, 30, 30, 0.1f);
        print("curent health is " + health);
        if (health <= 0)
        {
            print("You are Dead");
            Dead();
        }
    }
    public int GetHeals()
    {
        return heals;
    }

    public int GetMaxHeals()
    {
        return maxHeals;
    }
    private void Heal()
    {
        if (heals > 0)
        {
            data.playHealSound();
            float tempHp = health + healAmount;
            if (tempHp < maxHealth)
            {
                health += healAmount;
            }
            else
            {
                health = maxHealth;
            }
            heals--;
            print("your health is " + health);
        }
        print("you have " + heals + " healing items reminging");
    }
    private void Dead()
    {
        print("You Died");
        data.playDeathSound();
        playerAlive = false;
        Time.timeScale = 0f;
        
    }

    public void HealthFull()
    {
        health = maxHealth;
    }

    public void Respawn()
    {
        Reset();
        inventory.DropInventory();
        transform.position = spawn.transform.position;
        health = maxHealth;
        heals = maxHeals;
        Time.timeScale = 1f;
        playerAlive = true;
        menu.showDeathScreen(false);

    }
    public void ToStart()
    {
        transform.position = spawn.transform.position;
        playerAlive = true;
    }

    public void Reset()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            Destroy(enemy);
        }
        GameObject[] drops = GameObject.FindGameObjectsWithTag("Drop");
        foreach (GameObject drop in drops)
        {
            Destroy(drop);
        }
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(true);
        }
        GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>().SetUltCharge(0);
    }

    public void RefillHeals()
    {
        heals = maxHeals;
    }
    public void RefillHealth()
    {
        health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetMaxHealth(float healthIn)
    {
        maxHealth = healthIn;
    }
    public void UpdateAll()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        spawn = GameObject.FindWithTag("Respawn");
    }
    public void WipeAll()
    {
        spawners = null;
        spawn = null;
    }

    public void SetBoth(int[] inArr)
    {
        health = inArr[0];
        heals = inArr[1];
    }


    
}
