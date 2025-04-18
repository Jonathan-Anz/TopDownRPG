using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // Experience
    public int xpValue = 1;

    // Logic
    public float xSpeed = 1f;
    public float ySpeed = 0.75f;
    public float triggerLength = 1f;
    public float chaseLength = 5f;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    // Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        // Is the player in range?
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
            {
                chasing = true;
            }

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized, xSpeed, ySpeed);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position, xSpeed, ySpeed);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position, xSpeed, ySpeed);
            chasing = false;
        }

        // Check for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            // The array is not cleaned up, so we do it ourselves
            hits[i] = null;
        }

    }

    protected override void Death()
    {
        Destroy(gameObject);
        if (gameObject.name == "Boss")
        {
            //Debug.Log("Boss defeated");
            GameManager.instance.defeatedBoss = true;
        }
        // GameManager.instance.experience += xpValue;
        // GameManager.instance.ShowText(  $"+{xpValue} xp",
        //                                 30,
        //                                 Color.magenta,
        //                                 transform.position,
        //                                 Vector3.up * 30f,
        //                                 1f);
    }

}