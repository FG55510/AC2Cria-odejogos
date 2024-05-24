using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveEnding : MonoBehaviour
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

        float moveX = Input.GetAxisRaw("Horizontal");


        Vector2 moveDir = new Vector2(moveX, 0).normalized;
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;

        if (moveDir.x < 0)
        {
            sr.flipX = true;

        }
        else
        {
            sr.flipX = false;
        }
    }
}
