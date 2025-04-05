using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public float xSpeed = 1f;
    public float ySpeed = 0.75f;
    public int strength = 0;
    public float staminaRechargeRate = 2f;
    public Weapon currentWeapon;

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0f).normalized, xSpeed, ySpeed);
    }
}