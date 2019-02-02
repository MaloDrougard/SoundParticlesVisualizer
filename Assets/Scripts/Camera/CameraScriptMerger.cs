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

public class CameraScriptMerger : MonoBehaviour
{

    public AutoCameraScript autoCam = null;
    public ManualCameraScript manualCam = null;



    // Use this for initialization
    void Start()
    {

        this.CheckDependencies();
        autoCam.Pause();
    }

    // Update is called once per frame
    void Update()
    {

        if (manualCam.isPilot)
        {
            autoCam.Pause();
        }
        if (Input.GetButtonDown("CamGoInAutoPath"))
        {
            manualCam.SetIsPilot(false);
            manualCam.ResetRotation();
            autoCam.MoveDirectlyToNext();
            autoCam.Play();
        }
        if (Input.GetButton("CamGoInInitPosition"))
        {
            autoCam.Pause();
            manualCam.SetIsPilot(true);
            this.transform.position = Settings.centerP + new Vector3(0,0,-300);
            this.transform.LookAt(Settings.centerP);
            manualCam.ResetRotation();
            Debug.Log("input ok");
         
                    
        }




    }


    public void CheckDependencies()
    {

        if (autoCam == null)
        {
            Debug.LogWarning("CAMERASCRIPTMERGER: autoCam not set!");
        }

        if (manualCam == null)
        {
            Debug.LogWarning("CAMERASCRIPTMERGER: manualCam not set!");
        }


    }
}
