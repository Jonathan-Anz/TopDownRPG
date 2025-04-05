using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite weaponSprite;
    public int weaponDamage;
    public float staminaAmount;
    public float weaponPushForce;
    public float weaponCooldown;
}