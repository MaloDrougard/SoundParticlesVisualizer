/*
* Copyright (C) 2017-2019 Makem Corporation 
* 
* Created: 2018 Malo Drougard <malo.drougard@protonmail.com>
* 
* This file is part of SoundParticlesVisualizer (SPV).
* 
* SPV is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* any later version.
*
* SPV is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with SPV.  If not, see <https://www.gnu.org/licenses/>.
*
*/


﻿using System.Collections;
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

