using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour {

    public float speed;
    private playerController player;
    public float projectileLifeDist;
    public int damage;
   private Vector2 startPosition;
   public GameObject bulletParticle;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<playerController>();
        if (player.GetComponent<Rigidbody2D>().transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        if(Mathf.Abs(transform.position.x - startPosition.x) > projectileLifeDist)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Enemy")
        {
            // Instantiate(deathEffect, collision.GetComponent<Transform>().position, collision.GetComponent<Transform>().rotation);
            // Destroy(collision.gameObject);
            collision.GetComponent<EnemyHealthManager>().takeDamage(damage);
            Destroy(gameObject);
            Instantiate(bulletParticle, transform.position, transform.rotation);
        }
        else if(collision.tag != "Checkpoint")
        {
            Destroy(gameObject);
            Instantiate(bulletParticle, transform.position, transform.rotation);
        }
        
    }
}
