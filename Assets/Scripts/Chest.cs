using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{
    public Sprite emptyChest;
    public int pesosAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //Debug.Log($"Grant {pesosAmount} pesos!");
            GameManager.instance.ShowText(  $"+{pesosAmount} pesos!",
                                            25,
                                            Color.yellow,
                                            transform.position,
                                            Vector3.up * 35f,
                                            1.5f );

        }
    }
}