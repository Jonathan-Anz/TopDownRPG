using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct
    public int damagePoint = 1;
    public float pushForce = 2f;

    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }        
    }

    protected override void OnCollide(Collider2D col)
    {
        if (col.tag != "Fighter") return;

        if (col.name == "Player") return;

        //Debug.Log(col.name);

        // Create new damage object then send it to the fighter that was hit
        Damage dmg = new Damage(transform.position, damagePoint, pushForce);

        col.SendMessage("ReceiveDamage", dmg);
    }

    private void Swing()
    {

    }

}