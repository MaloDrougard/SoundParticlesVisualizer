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

public class SoundDrawer : MonoBehaviour {



    
    int samplesSize;
    public LineRenderer line = null;

    Vector3 baseHeight = new Vector3(0, 10, 0);
    Vector3 horizontalStep = new Vector3(0.1f, 0, 0);


	// Use this for initialization
	void Start () {
   
	}


    public void Init(int samplesSize)
    {
        this.samplesSize = samplesSize;

        line.positionCount = samplesSize; 
    }


    public void DisplaySamples(float[] samples)
    {
        int i = 0;
        foreach( float v in samples)
        {
            line.SetPosition(i, v * baseHeight + i * horizontalStep);
            i++;
         }
    }


}
