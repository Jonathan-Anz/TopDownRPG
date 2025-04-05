using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LootType
{
    Weapon, Potion
}
public enum PotionType
{
    Health, Stamina, Speed, Strength
}

public class Chest : Collectible
{
    public Sprite emptyChest;
    public LootType lootType;
    public WeaponData weapon;
    public PotionType potionType;
    //public int coinAmount;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;

            string message = "";
            // if (lootType == LootType.Coins)
            // {
            //     GameManager.instance.coins += coinAmount;
            //     message = $"+{coinAmount} coins!";
            // }
            if (lootType == LootType.Weapon)
            {
                GameManager.instance.AddWeapon(weapon);
                message = $"Found {weapon.weaponName}!";
            }
            else if (lootType == LootType.Potion)
            {
                GameManager.instance.potions[(int)potionType] += 1;
                message = $"Found {potionType} potion!";
            }
            
            GameManager.instance.ShowText(  message,
                                            25,
                                            Color.yellow,
                                            transform.position,
                                            Vector3.up * 35f,
                                            1.5f );
        }
    }
    
}