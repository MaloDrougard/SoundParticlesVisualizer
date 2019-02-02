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

public class GradientCreator  {
    

    public Gradient CreateGradientTwoColor(Color a, Color b)
    {
        Debug.Log("gradiennnt");

        Gradient gradient = new Gradient();

        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(a, 0.0f),
                new GradientColorKey(b, 1.0f) },
            new GradientAlphaKey[] {
                new GradientAlphaKey(0.0f, 0.0f),
                new GradientAlphaKey(1.0f, 0.2f),
                new GradientAlphaKey(0.4f, 0.7f),
                new GradientAlphaKey(0.0f, 1.0f) });

        return gradient;

    }




}
