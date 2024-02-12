using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float input;
    public float jumpPower;
    private int coins = 0;
    private int lives = 3;
    private bool facingRight = true;
    private bool jumping = false;
    public TextMeshProUGUI CoinText;
    public GameObject[] LivesImages;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public GameObject SlashPrefab;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        if(input < 0 && facingRight)
        {
            Flip();
        }
        else if(input > 0 && !facingRight) 
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && jumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumping = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Slash();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            audioManager.PlaySFX(audioManager.coinPickup);
            coins += 1;
            CoinText.text = coins.ToString("0");
            Destroy(collision.gameObject);
            if(coins == 5)
            {
                YouWin();
            }
        }

        if (collision.collider.CompareTag("Death") || collision.collider.CompareTag("Enemy"))
        {
            if (lives <= 0)
            {
                audioManager.PlaySFX(audioManager.finalDeath);
                GameOver();
            }
            else
            {
                audioManager.PlaySFX(audioManager.death);
                lives--;
                LivesImages[lives].SetActive(false);
                transform.position = new Vector3(-5, -1.5f, 0);
            }
        }

        if (collision.collider.CompareTag("Ground"))
        {
            jumping = false;
        }
    }

    private void Slash()
    {
        audioManager.PlaySFX(audioManager.swordSlash);
        if (facingRight)
        {
            var SlashPos = new Vector2(rb.transform.localPosition.x + (transform.right.x * 1.5f), rb.transform.localPosition.y);
            Instantiate(SlashPrefab, SlashPos, Quaternion.identity);
        }
        else if(!facingRight)
        {
            var SlashPos = new Vector2(rb.transform.localPosition.x - (transform.right.x * 1.5f), rb.transform.localPosition.y);
            Instantiate(SlashPrefab, SlashPos, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        }
        
    }
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;

    }
    private void GameOver()
    {
        GameOverPanel.SetActive(true);
        Destroy(gameObject);
    }
    private void YouWin()
    {
        WinPanel.SetActive(true);
    }
}
