using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Public fields
    public int health = 10;
    public int maxHealth = 10;
    public float stamina = 10;
    public float maxStamina = 10;
    public float pushRecoverySpeed = 0.2f;

    // Immunity
    protected float immuneTime = 1f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;

    // All fighters can ReceiveDamage / Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune <= immuneTime) return;

        lastImmune = Time.time;
        health -= dmg.damageAmount;
        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

        GameManager.instance.ShowText(  dmg.damageAmount.ToString(),
                                        15,
                                        Color.red,
                                        transform.position,
                                        Vector3.zero,
                                        0.5f);

        if (health <= 0)
        {
            health = 0;
            Death();
        }
    }
    protected virtual void Death()
    {

    }
}