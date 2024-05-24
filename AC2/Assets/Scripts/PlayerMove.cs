using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    public SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Movement
        Vector2 moveDir = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;

        if(moveDir.x < 0)
        {
            sr.flipX = true;

        }
        else
        {
            sr.flipX = false;
        }
    }
}

