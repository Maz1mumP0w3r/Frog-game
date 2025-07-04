using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Enemy : MonoBehaviour
{


    public float speed;
    public bool flip;
    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public float jumpInterval = 2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float jumpTimer;

    public GameObject targetPlayer;

    public enum EnemyState
    {
        PURPLE,
        BLUE,
        PINK,
        YELLOW
    }

    public EnemyState myState;
    public Animator myAnim;
    
    

    bool isStunned;
    bool canDamagePlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = jumpInterval;
        myState = EnemyState.PURPLE;
    }


    void FixedUpdate()
    { 
        
        jumpTimer -= Time.deltaTime;

        switch(myState)
        {
            case EnemyState.PURPLE:
            //code that runs when the enemy is MEAN
            FollowPlayer();
            break;

            case EnemyState.BLUE:
            //code that runs when the enemy is FRIENDLY
            
            if (jumpTimer <= 0f && IsGrounded())
            {
                Jump();
                jumpTimer = jumpInterval;
            }

            break;
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset vertical velocity
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void FollowPlayer()
    {
        
        Vector3 scale = transform.localScale;


        if (targetPlayer.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1;
                transform.Translate(x: speed * Time.deltaTime, y: 0, z: 0);

            }
        else
            {
                scale.x = Mathf.Abs(scale.x);
                transform.Translate(x: speed * Time.deltaTime * -1, y: 0, z: 0);
            }
        


            transform.localScale = scale;
    }


    void SetState(EnemyState s)
    {
        if(myState == s) {return;} //if we're already in this state, then EXIT FUNCTION


        myState = s;

        if(myState == EnemyState.BLUE)
        {
            myAnim.Play("BlueIdle");
        }

        if(myState == EnemyState.PURPLE)
        {
            myAnim.Play("PurpleIdle");
        }


        //if(CONDITION TO BECOME FRIENDLY == TRUE)
        //set state == FRIENDLY
    }

    public void ApplyStun()
    {
        if (!isStunned)
        {
            isStunned = true;
            canDamagePlayer = false;
            SetState(EnemyState.BLUE);
            // Optionally stop movement, animations, etc.
            StopAllCoroutines(); // Stop behavior if you're using coroutines
            Debug.Log($"{gameObject.name} has been permanently stunned.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canDamagePlayer && collision.gameObject.CompareTag("Player"))
        {
            // Deal damage or apply effects to the player
        }
    }



    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }


}
