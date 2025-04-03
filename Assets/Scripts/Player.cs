using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0f).normalized;

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