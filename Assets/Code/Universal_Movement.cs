using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universal_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float input;
    public float jumpPower;
    public bool facingRight = true;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Left and right controls + flip the sprite depending on direction moving
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        if (input < 0 && facingRight)
        {
            Flip();
        }
        else if (input > 0 && !facingRight)
        {
            Flip();
        }

        //If the player is in the air, don't allow more jumping
        if (Input.GetButtonDown("Jump") && jumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumping = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Allow the player to jump once they touch the ground
        if (collision.collider.CompareTag("Ground"))
        {
            jumping = false;
        }
    }


    private void Flip()
    //Function to flip the sprite
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;

    }
}
