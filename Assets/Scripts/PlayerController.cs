using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private BoxCollider2D player;
    private Rigidbody2D rb2d;
    [SerializeField]
    private PickUpKeys puk;
    [SerializeField]
    private GameOver go;
    [SerializeField]
    private DeathCount dc;
    [SerializeField]
    private HPController hp;

    private int lives;

    private bool isDead=false;
    private bool isHurt = false;
    private bool isFacingRight = true;
    
    //private int deaths;
    private bool isGrounded;
    private void Awake()
    {
        lives = 3;
        dc.gameObject.SetActive(true);
        puk.gameObject.SetActive(true);
        //deaths = 0;
        isGrounded = true;
        Debug.Log("Player Controller awake");
        player = gameObject.GetComponent<BoxCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("You have lives: " + lives);
    }

    // Start is called before the first frame update
    void Start()
    {}


    // Update is called once per frame
    void Update()
    {
        if (!isDead && !isHurt)
        {
            //Running and turning
            LeftRight();
            //Crouching
            Crouch();
            //Jumping
            if (isGrounded) Jump();
        }
        else {
            if (Input.GetKeyDown(KeyCode.R))
            {
                LoadLevel(1);
            }
        }
        
    }

    internal void KillPlayer()
    {
        Debug.Log("LOL you died noob");
        animator.SetBool("IsDead", true);

        if (isFacingRight) rb2d.AddForce(new Vector2(-1000f, 1000f));
        else rb2d.AddForce(new Vector2(800f, 800f));
        isDead = true;
        go.Gameover();

    }

    public void LoadLevel(int v)
    {
        SceneManager.LoadScene(v);
    }



    internal void pickUpKey()
    {
        Debug.Log("You picked up a key!");
        puk.KeyPicked();

    }

    void LeftRight() {
        float speed = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            if (speed < -0.5 && !Input.GetKey(KeyCode.LeftControl))
            {
                transform.position += Vector3.right * 3 * speed * Time.deltaTime;
                isFacingRight = false;
            }
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            if (speed > 0.5 && !Input.GetKey(KeyCode.LeftControl))
            {
                transform.position += Vector3.right * 3 * speed * Time.deltaTime;
                isFacingRight = true;
            }
        }
        transform.localScale = scale;
    }
    void Crouch() {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetBool("IsCrouch", true);
            player.size = new Vector2(player.size.x, (player.size.y) * 0.6f);
            player.offset = new Vector2(player.offset.x, (player.offset.y) * 0.6f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            animator.SetBool("IsCrouch", false);
            player.size = new Vector2(player.size.x, (player.size.y) / 0.6f);
            player.offset = new Vector2(player.offset.x, (player.offset.y) / 0.6f);
        }
    }
    void Jump() {
        /*float jump = Input.GetAxis("Jump");
       if (jump > 0)
       {
           animator.SetBool("Jump", true);
           rb2d.AddForce(new Vector2(0, jump*40), ForceMode2D.Force);
       }
       else {   
           animator.SetBool("Jump", false);
       }*/
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.AddForce(new Vector2(0, 28), ForceMode2D.Impulse);
                animator.SetBool("Jump", true);
                isGrounded = false;
            }
            /*else if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("Jump", false);
            }*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }

        else if (collision.gameObject.CompareTag("Spikes")) {
            PlayerHurt();
        }
    }

    public void PlayerHurt() {
        if (lives-1 == 0)
        {
            KillPlayer();
            hp.transform.Find("Heart" + lives).gameObject.SetActive(false);
            dc.PlayerDied();
        }

        else {
            isHurt = true;
            Debug.Log("Player got hurt");
            animator.SetTrigger("IsHurt");
            if (isFacingRight) rb2d.AddForce(new Vector2(-800f, 800f));
            else rb2d.AddForce(new Vector2(800f, 800f));
            hp.transform.Find("Heart" + lives).gameObject.SetActive(false); 
            Debug.Log("You have lives: " + lives--);

            isHurt = false;
        }
    }
}   
