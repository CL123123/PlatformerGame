using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticleSystem : MonoBehaviour {

    private ParticleSystem theParticleSystem;
	// Use this for initialization
	void Start () {
        theParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (theParticleSystem.isPlaying)
            return;
        Destroy(gameObject);
	}
}
