using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour {

    // The particules system managed by this controller
    public ParticleSystem particles = null;

    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.VelocityOverLifetimeModule velocity; 

    public Vector3 acctualScale = new Vector3(1, 1, 1);
    

	void Start () {
       emission = particles.emission;
       velocity = particles.velocityOverLifetime; 
    }
	



    
    public void ChangeEmmision(float newEmissionRate)
    {
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(newEmissionRate);

    }

    public void ChangeVelocity(float newVelocityMultiplier)
    {

        //var curve = new AnimationCurve(new Keyframe(1, 0), new Keyframe(0.1f, 1));
        velocity.speedModifier = new ParticleSystem.MinMaxCurve( newVelocityMultiplier)  ;


    }



}

