using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour {

    public ParticleSystem particles = null;


    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.VelocityOverLifetimeModule velocity; 

    public Vector3 acctualScale = new Vector3(1, 1, 1);
    

	// Use this for initialization
	void Start () {
       emission = particles.emission;
        velocity = particles.velocityOverLifetime; 
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            this.ChangeEmmision(10);
            this.ChangeVelocity(10); 
        }
        if(Input.GetKey("g"))
        {
            acctualScale += Time.deltaTime * new Vector3(1, 1, 1);
            this.Scale(acctualScale); 
        }
        if (Input.GetKey("v"))
        {
            acctualScale -= Time.deltaTime * new Vector3(1, 1, 1);
            this.Scale(acctualScale);
        }

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

    public void Scale(Vector3 scale)
    {
        particles.transform.localScale = scale ;

    }

}

