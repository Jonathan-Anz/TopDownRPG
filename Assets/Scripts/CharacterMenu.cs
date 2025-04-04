using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public TextMeshProUGUI healthText, levelText, coinText, xpText;

    // Logic
    public Sprite[] weaponSprites = new Sprite[4];
    public RectTransform xpBar;

    // Update character information
    public void UpdateMenu()
    {
        // Weapon

        // Meta
        levelText.text = "NOT IMPLEMENTED";
        healthText.text = GameManager.instance.player.hitPoint.ToString();
        coinText.text = GameManager.instance.coins.ToString();

        // XP bar
        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector3(0.5f, 1f, 1f);
    }

}