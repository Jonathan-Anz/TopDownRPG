using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Collidable
{
    // Logic
    protected bool collected;

    protected override void OnCollide(Collider2D col)
    {
        if (col.name == "Player") OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}