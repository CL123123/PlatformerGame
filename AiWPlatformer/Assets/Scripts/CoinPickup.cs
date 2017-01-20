using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
    public int pointValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<playerController>() == null)
            return;
        ScoreManager.addPoints(pointValue);
        Destroy(gameObject);
    } 
}
