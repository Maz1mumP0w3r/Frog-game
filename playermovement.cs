using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer mySprite;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput < 0f)
        {
            mySprite.flipX = true;
        }

        if(moveInput > 0f)
        {
            mySprite.flipX = false;
        }

    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}
