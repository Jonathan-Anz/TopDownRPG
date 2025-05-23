using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Weapon data
    private SpriteRenderer spriteRenderer;
    public int damage = 0;
    public float staminaAmount;
    public float pushForce = 0f;
    private float cooldown = 0f;

    // Swing
    private Animator anim;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown &&
                GameManager.instance.player.stamina >= staminaAmount)
            {
                lastSwing = Time.time;
                GameManager.instance.player.stamina -= staminaAmount;
                Swing();
            }
        }        
    }

    public void SetCurrentWeapon(WeaponData weapon)
    {
        spriteRenderer.sprite = weapon.weaponSprite;
        damage = weapon.weaponDamage;
        staminaAmount = weapon.staminaAmount;
        pushForce = weapon.weaponPushForce;
        cooldown = weapon.weaponCooldown;
    }

    protected override void OnCollide(Collider2D col)
    {
        if (col.tag != "Fighter") return;

        if (col.name == "Player") return;

        //Debug.Log(col.name);

        // Create new damage object then send it to the fighter that was hit
        Damage dmg = new Damage(transform.position, damage + GameManager.instance.player.strength, pushForce);

        col.SendMessage("ReceiveDamage", dmg);
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");
    }

}