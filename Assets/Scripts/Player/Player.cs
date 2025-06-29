using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float health;
    bool isToFountin = false;
    string toFountain;
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
    private float trapTime;
    private float trapTimeEnd;
    //private int trapWrigleThreshold;
    private Rigidbody2D rb;
    private Animator Animator;
    HealsUI fountainUI;
    public bool GetPlayerAlive()
    {
        return playerAlive;
    }

    void Start()
    {
        Animator = transform.gameObject.GetComponent<Animator>();
        rb = transform.gameObject.GetComponent<Rigidbody2D>();
        menu = GameObject.FindWithTag("UI").GetComponent<MenuHandler>();
        health = maxHealth;
        heals = maxHeals;
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        spawn = GameObject.FindWithTag("Respawn");
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        menu.showDeathScreen(false);
        fountainUI = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(1).gameObject.GetComponent<HealsUI>();
    }
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
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Heal();
            }
            if (data.getTrapped())
            {
                data.SetCanAttack(false);
                Animator.SetBool("trapped", true);
                rb.linearVelocity = Vector2.zero;
                data.setCanMove(false);
                trapTime += Time.deltaTime;

                if (trapTime >= trapTimeEnd)
                {
                    data.setTrapped(false);
                    data.setCanMove(true);
                    Animator.SetBool("trapped", false);
                    data.SetCanAttack(true);
                }
            }
            else
            {
                Animator.SetBool("trapped", false);
            }
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
    public void trapDamage(float initialDamage, float timeEnd)
    {
        this.damage(initialDamage);
        trapTime = 0;
        trapTimeEnd = timeEnd;
        data.setTrapped(true);
    }
    public int GetHeals()
    {
        return heals;
    }
    public void SetMaxHeals(int healsNew)
    {
        maxHeals = healsNew;
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
        toRespawnPoint();
        HealthFull();
        RefillHeals();
        Time.timeScale = 1f;
        playerAlive = true;
        menu.showDeathScreen(false);

    }
    private void toRespawnPoint()
    {
        try
        {
            DieToFountain(data.getLastFountain());
        }
        catch (IndexOutOfRangeException ex)
        {
            Debug.Log(ex);
            GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>().GoToScene(SceneManager.GetActiveScene().name);
        }

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
        fountainUI.Fountain();
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
    public void GoToFountain(string fountainID)
    {
        string scene = "";
        switch (fountainID[0])
        {
            case '0':
                scene = "Start Tut Block";
                break;
            case '1':
                scene = "Village Area";
                break;
            case '2':
                scene = "Level 2";
                break;
            case '3':
                scene = "Boss Fight";
                break;
        }
        GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>().SetCahingID(2);
        if (SceneManager.GetActiveScene().name != scene)
        {
            GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>().GoToScene(scene);
            isToFountin = true;
            toFountain = fountainID;
        }
        else
        {
            GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>().Stay();
            GameObject[] fountains = GameObject.FindGameObjectsWithTag("Fountain");
            foreach (GameObject i in fountains)
            {
                if (i.GetComponent<FountainID>().GetID() == fountainID)
                {
                    transform.position = spawn.transform.position = i.transform.GetChild(0).position - new Vector3(0, 5, 60);
                    break;
                }
            }
        }
    }
    public void DieToFountain(string fountainID)
    {
        string scene = "";
        switch (fountainID[0])
        {
            case '0':
                scene = "Start Tut Block";
                break;
            case '1':
                scene = "Village Area";
                break;
            case '2':
                scene = "Level 2";
                break;
            case '3':
                scene = "Boss Fight";
                break;
        }
        if (SceneManager.GetActiveScene().name != scene)
        {
            GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>().DieToScene(scene);
        }
        GameObject[] fountains = GameObject.FindGameObjectsWithTag("Fountain");
        foreach (GameObject i in fountains)
        {
            if (i.GetComponent<FountainID>().GetID() == fountainID)
            {
                transform.position = spawn.transform.position = i.transform.GetChild(0).position - new Vector3(0, 5, 60);
                break;
            }
        }
    }
    public void StartScene(){
        if(isToFountin){
            isToFountin = false;
            GoToFountain(toFountain);
        }
    }

    
}
