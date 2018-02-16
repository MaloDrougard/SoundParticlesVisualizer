using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour {

    // The particules system managed by this controller
    public ParticleSystem particles = null;

    public float velocityFactor = 1;
    public float emissionFactor = 1; 

    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.VelocityOverLifetimeModule velocity; 

    public Vector3 acctualScale = new Vector3(1, 1, 1);
    

	void Start () {
       emission = particles.emission;
       velocity = particles.velocityOverLifetime; 
    }
	

    public void ChangeEmmision(float newEmissionRate)
    {
        emission.rateOverTime = new ParticleSystem.MinMaxCurve( emissionFactor * newEmissionRate);
    }


    public void ChangeVelocity(float newVelocityMultiplier)
    {
        velocity.speedModifier = new ParticleSystem.MinMaxCurve(velocityFactor *  newVelocityMultiplier)  ;
    }



}

