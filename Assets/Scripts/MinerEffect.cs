using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerEffect : MonoBehaviour {
    public ParticleSystem particle;
	// Use this for initialization
	void Start () {
		
	}

    internal void SetHashRate(int calcPower)
    {
        var emission = particle.emission;
        emission.rateOverTime = calcPower;
    }
}
