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
    Vector2 mouse;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);


        //Left and right controls + flip the sprite depending on direction moving
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);


        // Mouse on left side
        if ((mouse.x < Screen.width / 2) && facingRight)
        {
            Flip();
        }


        // Mouse on right side
        if ((mouse.x > Screen.width / 2) && !facingRight)
        {
            Flip();
        }




        // if (input < 0 && facingRight)
        //  {
        //     Flip();
        // }


        //If the player is in the air, don't allow more jumping
        if ((Input.GetButtonDown("Jump") && jumping == false) || (Input.GetKeyDown("w") && jumping == false))
        {
            AudioManager.Instance.PlaySFX("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumping = true;
        }

    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Allow the player to jump once they touch the ground
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Cactus"))
        {
            jumping = false;
        }
    }


    private void Flip()
    {
        // Flip the parent GameObject
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;

        // Flip the first four children of the GameObject
        int childrenToFlip = Mathf.Min(gameObject.transform.childCount, 1); // Ensure we don't exceed the number of children
        for (int i = 0; i < childrenToFlip; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            Vector3 childScale = child.localScale;
            childScale.x *= -1;
            child.localScale = childScale;
        }
    }
}