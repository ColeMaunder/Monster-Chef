using UnityEngine;
using System;
using System.IO;

public class PlayerStorage : MonoBehaviour
{
    [SerializeField]
    private TextAsset playerFile;
    private PlayerData data;
    private PlayerInventory inventory;
    private Player player;
    private WeaponAttacks weapons;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        weapons = GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>();
        string[] lines = playerFile.text.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        data.setActiveWepon(int.Parse(lines[0]));
        weapons.SetUltCharge(int.Parse(lines[1]));

        string[] unlockedRecipes = lines[2].Split(",", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < unlockedRecipes.Length; i++)
        {
            bool status = unlockedRecipes[i] == "y";
            data.SetUnlockedRecipe(i, status);
        }

        inventory.SetInventory(Array.ConvertAll(lines[3].Split(",", StringSplitOptions.RemoveEmptyEntries), int.Parse));

        player.SetBoth(Array.ConvertAll(lines[4].Split(",", StringSplitOptions.RemoveEmptyEntries), int.Parse));
    }

    public void Save()
    {
        string inventoryStr = "";
        string recipesStr = "";

        for (int i = 0; i < inventory.GetInventory().Length; i++)
        {
            inventoryStr += inventory.GetItem(i) + ",";
        }

        for (int i = 0; i < data.GetUnlockedRecipes().Length; i++)
        {
            if (data.GetUnlockedRecipe(i))
            {
                recipesStr += "y,";
            }
            else
            {
                recipesStr += "n,";
            }
        }

        string storeData = "";
        storeData += data.getActiveWepon() + "\n";
        storeData += weapons.GetUltCharge() + "\n";
        storeData += recipesStr + "\n";
        storeData += inventoryStr + "\n";
        storeData += player.GetHealth() + "," + player.GetHeals() + "\n";

        using (var writer = new StreamWriter(storeData, false))
        {
            writer.WriteLine(playerFile);
        }
    }
        
}

