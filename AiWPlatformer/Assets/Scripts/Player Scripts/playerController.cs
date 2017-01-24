using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public Transform firePoint;
    public GameObject bullet;
    public float shotDelay;
    private float shotDelayCounter;

    private bool grounded;
    private bool doubleJumped;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        doubleJumped = false;
        shotDelayCounter = 0f;
	}

    // Update is called once per frame
    void Update() {
        if (grounded)
        {
            doubleJumped = false;
        }
        // Jump only if on the ground
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJumped)
        {
            doubleJumped = true;
            jump();
        }
        moveVelocity = 0f;
        // Control movement of player with A and D
        if (Input.GetKey(KeyCode.A))
        {
            // GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity -= moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity += moveSpeed;
        }

        // Fire a bullet when Enter is pressed
        /*
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            shotDelayCounter = shotDelay;
        }
        */
        shotDelayCounter -= Time.deltaTime;
        // Fire another bullet after set amount of time with Enter pressed down
        if(Input.GetKey(KeyCode.Return))
        {
            if(shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }

        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        // Debug.Log(GetComponent<Rigidbody2D>().velocity.x);
        // Set player animation bools and variables
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
        flipPlayer();
    }

    public void jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    // Flip the player based on velocity
    private void flipPlayer()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private void FixedUpdate()
    {
        // Checks if on the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
    }
}
