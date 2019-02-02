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





public class AutoCameraScript : MonoBehaviour
{


    // State of the autocamera motion
    public enum AutoCameraState { PLAY, PAUSE, UNDEFINE }
    public AutoCameraState state = AutoCameraState.UNDEFINE;

    // List of the position and transition the camera should take
    public List<AutoCameraShot> camShots = null;

    // acctual camera seetitngs
    public Transform target = null;
    int shotIdx = 0;
    public AutoCameraShot acctualShot = null;


    // private variable   
    public float moveSpeed = 1f;
    public float timer = 0;

    public Vector3 wantedTarget = Vector3.zero;
    public Vector3 wantedPosition = new Vector3(-1, -1, -1);




    void Start()
    {

        // Set camShots from Settings
        camShots = Settings.camShots;
        acctualShot = camShots[shotIdx];

        if (acctualShot.GetType() != typeof(PositionShot))
        {
            Debug.LogError("CAMERAAUTOMOTION: the first state should be a position");
        }

        // Get and set the first position
        wantedPosition = acctualShot.GetPosition();
        this.transform.position = wantedPosition;

        // Create the target game object
        InstantiateTarget();

        // Get and set the first lookAt target
        wantedTarget = acctualShot.GetTarget();
        target.position = wantedTarget;
        this.transform.LookAt(target);

        // set the timer
        timer = acctualShot.GetTimming();

        // set the state
        state = AutoCameraState.PLAY;
    }

    private void InstantiateTarget()
    {
        GameObject targetGameObject = new GameObject();
        targetGameObject.name = "LookAtTarget";
        target = targetGameObject.transform;

    }


    public void Pause()
    {
        state = AutoCameraState.PAUSE;
    }


    public void Play()
    {
        state = AutoCameraState.PLAY;
    }



    // Update is called once per frame
    void Update()
    {
        if (state == AutoCameraState.PLAY)
        {

            if (timer < 0)
            {
                SetNextShot();
            }

            if (this.transform.position != wantedPosition)
            {
                float delta = (wantedPosition - this.transform.position).magnitude;
                float velocity = delta / timer;
                float step = velocity * Time.deltaTime;
                this.transform.position = Vector3.MoveTowards(transform.position, wantedPosition, step);
                this.transform.LookAt(target);
            }


            if (target.position != wantedTarget)
            {
                float delta = (target.position - wantedTarget).magnitude;
                float velocity = delta / timer;
                float step = velocity * Time.deltaTime;
                target.position = Vector3.MoveTowards(target.position, wantedTarget, step);
                this.transform.LookAt(target);
            }

            timer -= Time.deltaTime;
        }


    }

    /// <summary>
    /// Move directly to next shot.
    /// Usefull to reset the state if the camera was moved by another script
    /// <remark>
    /// The timer is not reset
    /// </remark>
    /// </summary>
    public void MoveDirectlyToNext()
    {
        this.transform.position = this.wantedPosition;
        this.transform.LookAt(wantedTarget);  // Rotate the container
    }


    private void SetNextShot()
    {
        // set the acttualShot
        shotIdx = (shotIdx + 1) % camShots.Count;
        acctualShot = camShots[shotIdx];

        if (acctualShot.type == AutoCameraShotType.POSITION)
        {
            timer = acctualShot.GetTimming();
            wantedPosition = acctualShot.GetPosition();
            wantedTarget = acctualShot.GetTarget();
        }
        else if (acctualShot.type == AutoCameraShotType.TRANSITION)
        {
            timer = acctualShot.GetTimming();

            // get the next postion 
            int tempIdx = (shotIdx + 1) % camShots.Count;
            AutoCameraShot nextCamState = camShots[tempIdx];
            if (nextCamState.type == AutoCameraShotType.POSITION)
            {
                wantedPosition = nextCamState.GetPosition();
                wantedTarget = nextCamState.GetTarget();

            }
            else
            {
                Debug.LogError("CAMERAAUTOMOTION: transition state should be follow by a poisition state");
            }

        }
    }


    public void CheckDependencies()
    {
        if (target == null)
        {
            Debug.LogWarning("CAMERAAUTOMOTION: we need a lootAt target");
        }
        if (camShots.Count == 0)
        {
            Debug.LogWarning("CAMERAAUTOMOTION: at least one camera position is needed to do auto-motion!");
        }
    }

}








public enum AutoCameraShotType { POSITION, TRANSITION }

/// <summary>
/// This class represent one shot (position or transition) of the motion of the camera
/// </summary>
public class AutoCameraShot
{

    public AutoCameraShotType type;


    public virtual Vector3 GetPosition()
    {
        Debug.LogWarning("AUTOCAMERASHOT: GetPosition() is not implemented!");
        return new Vector3(-1, -1, -1);
    }

    public virtual Vector3 GetTarget()
    {
        Debug.LogWarning("AUTOCAMERASHOT: GetTarget() is not implemented!");
        return new Vector3(-1, -1, -1);
    }

    /// <summary>
    /// Get the timming for the shot.
    /// Starring time will be returned for PositionShot and
    /// transition time will be returned for TransitionShot.
    /// </summary>
    /// <returns>Time in second that the shot should take</returns>
    public virtual float GetTimming()
    {
        Debug.LogWarning("AUTOCAMERASHOT: GetTimming() is not implemented!");
        return -1;
    }


}


public class PositionShot : AutoCameraShot
{


    public Vector3 position = Vector3.zero;
    public Vector3 target = Vector3.zero;
    public float staringTime = -1;

    public PositionShot(Vector3 inPosition, Vector3 inTarget, float inStaringTime)
    {
        base.type = AutoCameraShotType.POSITION;
        position = inPosition;
        target = inTarget;
        staringTime = inStaringTime;
    }

    public override Vector3 GetPosition()
    {
        return position;
    }

    public override Vector3 GetTarget()
    {
        return target;
    }

    public override float GetTimming()
    {
        return staringTime;
    }

}


public class TransitionShot : AutoCameraShot
{
    public float transitionTime = 0f;


    public TransitionShot(float inTime)
    {
        base.type = AutoCameraShotType.TRANSITION;
        transitionTime = inTime;
    }

    public override float GetTimming()
    {
        return transitionTime;
    }

}