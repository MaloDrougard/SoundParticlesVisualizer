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
/// This class allows this applicartion to have multiple display (physical monitor) 
/// </summary>
public class EnableDisplay : MonoBehaviour {

    public Camera mainCamera;
    public Canvas uiCanvas;
    public Camera uiCamera;

    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if one additional display is available and activate it.
        if (Display.displays.Length == 1)
            Debug.Log("Only one display detected");
        if (Display.displays.Length > 1)
        {
            Debug.Log("Two displays detected");
            Display.displays[1].Activate();
        }
        
    }

    public void SwitchDisplay()    
    {
        int display1 = mainCamera.targetDisplay ;
        int display2 = uiCamera.targetDisplay;

        mainCamera.targetDisplay = display2;
        uiCamera.targetDisplay = display1;
        uiCanvas.targetDisplay = display1;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchDisplay();
        }
    }



}
