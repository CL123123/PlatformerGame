using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHP;
    public GameObject deathEffect;
    public int pointsOnDeath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHP <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.addPoints(pointsOnDeath);
            Destroy(gameObject);
        }
	}

    public void takeDamage(int damage)
    {
        enemyHP -= damage;
        // Debug.Log("Health is now " + enemyHP);
    }
}
