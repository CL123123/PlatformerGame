using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthManager : MonoBehaviour {

	public static int playerHealth;
	public int maxPlayerHealth;
	Text text;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		playerHealth = maxPlayerHealth;
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0) {
			levelManager.respawnPlayer();
		}
		text.text = "" + playerHealth;
	}

	public static void damagePlayer (int damageToGive) 
	{
		playerHealth -= damageToGive;
	}

	public void fullHealth() 
	{
		playerHealth = maxPlayerHealth;
	}
}
