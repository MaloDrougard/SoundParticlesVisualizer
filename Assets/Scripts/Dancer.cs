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

public class Dancer : MonoBehaviour {

    public float amplitude = 0; 
    public Transform movingComponentT = null;

    // border of the circle (assuming that the object has no height)
    public Vector3 baseLocalPosition;  

    public void SetBAseLocalPosition(Vector3 basePos)
    {
        baseLocalPosition = basePos;
        movingComponentT.transform.localPosition = baseLocalPosition;
    }



    public void SetDoubleAmplitude(float ampli)
    {
        Vector3 scale = movingComponentT.localScale;
        scale.y = ampli;
        movingComponentT.localScale = scale;

      
    }

    public void SetAmplitude(float ampli)
    {
        Vector3 scale = movingComponentT.localScale;
        scale.y = ampli;
        movingComponentT.localScale = scale;

        movingComponentT.localPosition = baseLocalPosition + new Vector3(ampli / 2f, 0, 0);  
    }

 
}
