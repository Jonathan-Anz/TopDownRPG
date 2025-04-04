using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    // Damage
    public int damage = 1;
    public float pushForce = 5;

    protected override void OnCollide(Collider2D col)
    {
        if (col.tag == "Fighter" && col.name == "Player")
        {
            // Create a new damage object before sending it to player
            Damage dmg = new Damage(transform.position, damage, pushForce);

            col.SendMessage("ReceiveDamage", dmg);
        }
    }
}