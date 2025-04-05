using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public TextMeshProUGUI[] potionNumTexts = new TextMeshProUGUI[4];

    // Logic
    public Image[] weaponSprites = new Image[4];
    public Image[] keySprites = new Image[2];


    // Update character information
    public void UpdateMenu()
    {
        // Keys

        // Potions
        for (int i = 0; i < potionNumTexts.Length; i++)
        {
            potionNumTexts[i].text = GameManager.instance.potions[i].ToString();
        }
    }

    public void AddWeaponToMenu(int index, WeaponData data)
    {
        weaponSprites[index].sprite = data.weaponSprite;
        weaponSprites[index].enabled = true;
        //Debug.Log($"Added {data.name} to weapon slot {index + 1}");
    }

    public void SelectWeapon(int index)
    {
        //Debug.Log($"Weapon {index + 1} was selected");
        //Debug.Log($"Inventory weapons length is {GameManager.instance.inventoryWeapons.Count}");

        if (index > GameManager.instance.inventoryWeapons.Count - 1)
        {
            //Debug.Log($"Weapon slot locked!");
            return;
        }

        GameManager.instance.player.currentWeapon.SetCurrentWeapon(GameManager.instance.inventoryWeapons[index]);

        GameManager.instance.ShowText(  $"{GameManager.instance.inventoryWeapons[index].weaponName} selected",
                                        20,
                                        Color.cyan,
                                        Camera.main.ScreenToWorldPoint(new Vector3(400, 100, 0)),
                                        Vector3.zero,
                                        1f );
    }

    public void SelectPotion(int type)
    {
        //Debug.Log($"Selected {(PotionType)type} potion");
        GameManager.instance.UsePotion((PotionType)type);
    }

}