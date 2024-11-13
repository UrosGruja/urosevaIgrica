using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private enum MovementState { IDLE, RUNNING, JUMPING, FALLING }
    private MovementState state = MovementState.IDLE;

    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce = 17f;
    [SerializeField] private float moveSpeed = 7f;
    private float dirx;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirx > 0f)
        {
            state = MovementState.RUNNING;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.RUNNING;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.IDLE;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.JUMPING;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.FALLING;
        }


        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Die();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        Debug.Log("died");
        gameOverScreen.Setup();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
