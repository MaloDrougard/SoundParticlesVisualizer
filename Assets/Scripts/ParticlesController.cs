using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage one particles system.
/// 
/// Allow to have particular factors for each suns and to set the values.
/// </summary>
public class ParticlesController : MonoBehaviour {

    // The particules system managed by this controller
    public ParticleSystem particles = null;

    public float velocityFactor = 1;
    public float emissionFactor = 1;
    public float sizeFactor = 1; 

    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.VelocityOverLifetimeModule velocity;
    private ParticleSystem.SizeOverLifetimeModule size;
    private ParticleSystem.ColorOverLifetimeModule color;


    Gradient initialColor = new Gradient();

	void Start () {
       emission = particles.emission;
       velocity = particles.velocityOverLifetime;
       size = particles.sizeOverLifetime;
       color = particles.colorOverLifetime;
       initialColor = color.color.gradient; 
    }
	

    public void ChangeEmision(float newEmissionRate)
    {
        //Debug.Log( "Object: " + this.gameObject.name + " -> new emission rate:  " + newEmissionRate * emissionFactor); 
        emission.rateOverTime = new ParticleSystem.MinMaxCurve( emissionFactor * newEmissionRate);
    }


    public void ChangeVelocity(float newVelocityMultiplier)
    {
        // Debug.Log("Object: " + this.gameObject.name + " -> new velocity rate:  " + newVelocityMultiplier * velocityFactor );
        velocity.speedModifier = new ParticleSystem.MinMaxCurve(velocityFactor *  newVelocityMultiplier)  ;
    }


    public void ChangeSize(float newSize)
    {
        size.size = new ParticleSystem.MinMaxCurve(sizeFactor * newSize);
    }

    public void ChangeColor(Gradient gradient)
    {
        color.enabled = true;
        color.color = gradient;
    }

    public void ResetInitialColor()
    {
        color.color = initialColor;
    }



}

