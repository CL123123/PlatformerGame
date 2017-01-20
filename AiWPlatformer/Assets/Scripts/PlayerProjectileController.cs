using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour {

    public float speed;
    private playerController player;
    public float projectileLifeDist;
    public GameObject deathEffect;
    private Vector2 startPosition;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<playerController>();
        if (player.GetComponent<Rigidbody2D>().transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-1f, 1f, 1f);
            startPosition = transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Enemy")
        {
            Instantiate(collision, collision.GetComponent<Transform>().position, collision.GetComponent<Transform>().rotation);
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
