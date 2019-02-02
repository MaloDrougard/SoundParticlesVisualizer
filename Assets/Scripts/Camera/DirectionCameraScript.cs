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
/// Rotate the camera in the direction point by the cursor
/// 
/// </summary>
public class DirectionCameraScript : MonoBehaviour {

    public Transform cam = null;

    public float rotationSpeed = 0.2f; 
    // if it set to true the mouse move relativly to center otherwhise it move from relativly to the first click
    public bool RelativeToScreenCenter = false;
    private Vector3 mouseDeltaOrigin = new Vector3(Screen.width / 2, Screen.height / 2, 0);


    // Use this for initialization
    void Start () {
        this.CheckDependencies(); 
		
	}
	
	// Update is called once per frame
	void Update () {


                // Mouse control

                // set the origin of delta
                if (Input.GetMouseButtonDown(0))
                {
                    if (RelativeToScreenCenter)
                    {
                        mouseDeltaOrigin = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                    }
                    else
                    {
                       mouseDeltaOrigin = Input.mousePosition;
                    }

                }

                // rotation initiate by the mouse
                if (Input.GetMouseButton(0))
                {
                    var position = Input.mousePosition;
                    var delta = position - mouseDeltaOrigin;

                    this.cam.transform.Rotate(new Vector3(-1, 0, 0), delta.y * Time.deltaTime * rotationSpeed, Space.Self); // vertical rotation is relative to its self
                    this.cam.transform.Rotate(new Vector3(0, 1, 0), delta.x * Time.deltaTime * rotationSpeed, Space.World);  // horizontal rotation is relative to world
               
                }


            }

    public void CheckDependencies()
    {
        if(cam == null)
        {
            Debug.LogWarning("DIRECTIONCAMERASCRIPT: cam is null"); 
        }
    }




}
