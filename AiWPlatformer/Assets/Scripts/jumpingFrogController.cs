using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingFrogController : MonoBehaviour {
    public float jumpTime;
    public float jumpRandomness;
    public float jumpHeight;

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public Transform groundCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool onWall;
    private bool runningJumpCo;
    public bool grounded;

    private Animator anim;
    // Use this for initialization
    void Start () {
        runningJumpCo = false;
        anim = GetComponent<Animator>();
        StartCoroutine("jumpFrogCo");
    }


    // Update is called once per frame
    void Update()
    {
        // Check if the enemy has hit a wall. If it has, change the direction
        
        onWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0f, whatIsWall);
        if (onWall)
        {
            moveRight = !moveRight;
        }
        if(!runningJumpCo)
            StartCoroutine("jumpFrogCo");

        anim.SetBool("Grounded", grounded);
    }

    public IEnumerator jumpFrogCo()
    {
        runningJumpCo = true;
        if (moveRight && grounded)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, jumpHeight);
        }
        else if (!moveRight && grounded)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, jumpHeight);
        }
        
        yield return new WaitForSeconds(jumpTime + Random.Range(jumpRandomness, -jumpRandomness));
        runningJumpCo = false;
    }
}
