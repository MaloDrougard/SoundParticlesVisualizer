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

using UnityEngine.UI;

public class InterfaceInitiator : MonoBehaviour {

    public float sliderValues = 1;
    public bool toggleValues = true; 

	// Use this for initialization
	void Start () {

        Slider[] sliders = FindObjectsOfType<Slider>();
        foreach(Slider slider in sliders)
        {

            slider.value = sliderValues+1; // tricks to have the event onvaluechanged trigger each time
            slider.value = sliderValues;
            Debug.Log("slider " + slider.name + " set to " + sliderValues);

        }

        Toggle[] toggles = FindObjectsOfType<Toggle>();
        foreach(Toggle toggle in toggles)
        {
            toggle.isOn = !toggleValues; // tricks to have the event onvaluechanged trigger each time
            toggle.isOn = toggleValues;
            Debug.Log("toggle " + toggle.name + " set to " + toggleValues);
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
