using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float respawnDelay;
    public int deathPointPenalty;

    public GameObject currentCheckpoint;
    public GameObject deathParticle;
    public GameObject respawnParticle;

    private playerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void respawnPlayer()
    {
        StartCoroutine("respawnPlayerCo");
    }

    public IEnumerator respawnPlayerCo()
    {
        // Co-routine to respawn player. First, emits a death particle system. disable player and the animation,
        // wait for a delay, and then re-enable player and make visible, and create a respawn particle system.
        // Clean up the particle systems after they are used with Destroy.
        // Disable the collider so that enemies do not push the player after death.
        // Debug.Log("Player Respawned");
        float gravitySave = player.GetComponent<Rigidbody2D>().gravityScale;
        ScoreManager.addPoints(-deathPointPenalty);
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<CapsuleCollider2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(respawnDelay/2);
        player.transform.position = currentCheckpoint.transform.position;
        yield return new WaitForSeconds(respawnDelay / 2);
        player.GetComponent<CapsuleCollider2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = gravitySave;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        yield return new WaitForSeconds(respawnDelay);
        player.enabled = true;
    }
}
