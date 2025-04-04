using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0f);

        // Swap sprite direction, whether you're going right or left
        if (moveDelta.x > 0) transform.localScale = Vector3.one;
        else if (moveDelta.x < 0) transform.localScale = new Vector3(-1f, 1f, 1f);

        hit = Physics2D.BoxCast(transform.position, 
                                boxCollider.size, 
                                0f, 
                                new Vector2(0f, moveDelta.y), 
                                Mathf.Abs(moveDelta.y * Time.deltaTime), 
                                LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            // Move
            transform.Translate(0f, moveDelta.y * Time.fixedDeltaTime, 0f);
        }

        hit = Physics2D.BoxCast(transform.position, 
                                boxCollider.size, 
                                0f, 
                                new Vector2(moveDelta.x, 0f), 
                                Mathf.Abs(moveDelta.x * Time.deltaTime), 
                                LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            // Move
            transform.Translate(moveDelta.x * Time.fixedDeltaTime, 0f, 0f);
        }
    }

}