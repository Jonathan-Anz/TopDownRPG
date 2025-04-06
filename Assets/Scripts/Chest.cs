using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LootType { Weapon, Potion, Key }
public enum PotionType { Health, Stamina, Speed, Strength }
public enum KeyType { Enemy, Gold, Silver }

public class Chest : Collectible
{
    public Sprite emptyChest;
    public LootType lootType;
    public WeaponData weapon;
    public PotionType potionType;
    public KeyType keyType;
    //public int coinAmount;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;

            string message = "";
            Color color = Color.clear;
            // if (lootType == LootType.Coins)
            // {
            //     GameManager.instance.coins += coinAmount;
            //     message = $"+{coinAmount} coins!";
            // }
            if (lootType == LootType.Weapon)
            {
                GameManager.instance.AddWeapon(weapon);
                message = $"Found {weapon.weaponName}!";
                color = Color.cyan;
            }
            else if (lootType == LootType.Potion)
            {
                GameManager.instance.potions[(int)potionType] += 1;
                message = $"Found {potionType} potion!";
                switch (potionType)
                {
                    case PotionType.Health: color = Color.red; break;
                    case PotionType.Stamina: color = Color.green; break;
                    case PotionType.Speed: color = Color.blue; break;
                    case PotionType.Strength: color = Color.yellow; break;
                }
            }
            else if (lootType == LootType.Key)
            {
                message = $"Found {keyType} key!";
                switch (keyType)
                {
                    case KeyType.Gold:
                        GameManager.instance.hasGoldKey = true;
                        color =  Colors.gold;
                        GameManager.instance.menu.keySprites[0].enabled = true;
                        break;
                    
                    case KeyType.Silver:
                        GameManager.instance.hasSilverKey = true;
                        color = Colors.silver;
                        GameManager.instance.menu.keySprites[1].enabled = true;
                        break;
                }
            }
            
            GameManager.instance.ShowText(  message,
                                            25,
                                            color,
                                            transform.position,
                                            Vector3.up * 35f,
                                            1.5f );
        }
    }
    
}