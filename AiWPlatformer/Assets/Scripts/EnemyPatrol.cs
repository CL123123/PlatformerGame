using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public Transform groundCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool onWall;
    public bool grounded;

    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
        // Check if the enemy has hit a wall. If it has, change the direction
        anim.SetBool("Grounded", grounded);
        onWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        grounded = Physics2D.OverlapCircle(groundCheck.position, wallCheckRadius, whatIsWall);
        if(onWall)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (!moveRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        
    }
}
