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
/// 
/// Settings is the static class that hold the main camera path (via AutoCameraScript) 
/// 
/// </summary>
public static class Settings {

    static GradientCreator gradientCreator = new GradientCreator();


    // CAMERA PATH

    public const float GoldenNumber = 1.61803398874989484820458683436f;

    static Vector3 deltaXBetweenSuns = new Vector3(48, 0, 0);
    static Vector3 deltaYBetweenSuns = new Vector3(0, 54, 0);

    static Vector3 sun1P = new Vector3(24, 81, 0);
    static Vector3 sun2P = sun1P + 1 * deltaXBetweenSuns;
    static Vector3 sun3P = sun1P + 2 * deltaXBetweenSuns;
    static Vector3 sun4P = sun1P + 3 * deltaXBetweenSuns;

    static Vector3 sun5P = sun1P + (-1) * deltaYBetweenSuns;
    static Vector3 sun6P = sun1P + (-1) * deltaYBetweenSuns + 1 * deltaXBetweenSuns;
    static Vector3 sun7P = sun1P + (-1) * deltaYBetweenSuns + 2 * deltaXBetweenSuns;
    static Vector3 sun8P = sun1P + (-1) * deltaYBetweenSuns + 3 * deltaXBetweenSuns;

   public static Vector3 centerP = (sun1P + sun4P + sun5P + sun8P )/4;
    
    static float defaultStarringTime = 0;
    static float defaultTransitionTime = 13;

    public static List<AutoCameraShot> camShots = new List<AutoCameraShot>()
    {

        //// zig-zag     
        //new PositionShot(sun5P + new Vector3(0,0,-60) , sun5P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun6P + new Vector3(0,0,-60) , sun6P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun7P + new Vector3(0,0,-60) , sun7P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun8P + new Vector3(0,0,-60) , sun8P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),



        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 30),
        //new TransitionShot(defaultTransitionTime),


        //new PositionShot(sun1P + new Vector3(0,0,-60) , sun1P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun2P + new Vector3(0,0,-60) , sun2P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun3P + new Vector3(0,0,-60) , sun3P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun4P + new Vector3(0,0,-60) , sun4P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),



        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),




        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),


        //new PositionShot(sun5P + new Vector3(0,0,-60) , sun5P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),


        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun6P + new Vector3(0,0,-60) , sun6P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun7P + new Vector3(0,0,-60) , sun7P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun8P + new Vector3(0,0,-60) , sun8P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),



        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 30),
        //new TransitionShot(defaultTransitionTime),


        //new PositionShot(sun1P + new Vector3(0,0,-60) , sun1P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun2P + new Vector3(0,0,-60) , sun2P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),


        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun3P + new Vector3(0,0,-60) , sun3P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),


        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),

        //new PositionShot(sun4P + new Vector3(0,0,-60) , sun4P + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),



        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        //new TransitionShot(defaultTransitionTime),


        // new path
        //new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), defaultStarringTime),
        //new TransitionShot(defaultTransitionTime),

        new PositionShot(sun1P + new Vector3(-250,0,0), sun1P + new Vector3(-600,0,0), defaultStarringTime),
        new TransitionShot(0),    // come out of the dark 
        new PositionShot(sun1P + new Vector3(-15,0,0), sun1P + new Vector3(-100,0,0), defaultStarringTime),
        new TransitionShot(defaultTransitionTime),
        new PositionShot(sun1P + new Vector3(25,0,0), sun1P + new Vector3(-100,0,0), defaultStarringTime),
        new TransitionShot(defaultTransitionTime),
        new PositionShot(sun2P + new Vector3(25,0,0), sun1P + new Vector3(0,0,0), defaultStarringTime),
        new TransitionShot(defaultTransitionTime),
        new PositionShot(sun3P + new Vector3(25,0,0), sun2P + new Vector3(0,0,0), defaultStarringTime),
        new TransitionShot(defaultTransitionTime),
        new PositionShot(sun4P + new Vector3(35,0,0), sun3P + new Vector3(0,0,0), defaultStarringTime),
        new TransitionShot(1), // go in the dark 
        new PositionShot(sun4P + new Vector3(200,0,0), sun4P + new Vector3(0,0,0), defaultStarringTime),
        new TransitionShot(0),
        // seconde row

        new PositionShot(sun5P + new Vector3(-250,0,0), sun5P + new Vector3(-600,0,0), defaultStarringTime),
        new TransitionShot(0),    // come out of the dark 
        new PositionShot(sun5P + new Vector3(-15,0,0), sun5P + new Vector3(-100,0,0), defaultStarringTime),
        new TransitionShot(defaultTransitionTime),
        new PositionShot(sun5P + new Vector3(25,0,0), sun5P + new Vector3(-100,0,0), defaultStarringTime),
        new TransitionShot(defaultTransitionTime),
        new PositionShot(sun6P + new Vector3(25,0,0), sun5P + new Vector3(0,0,0), defaultStarringTime),
        new TransitionShot(defaultTransitionTime),
        new PositionShot(sun7P + new Vector3(25,0,0), sun6P + new Vector3(0,0,0), defaultStarringTime),
        new TransitionShot(defaultTransitionTime),
        new PositionShot(sun8P + new Vector3(35,0,0), sun7P + new Vector3(0,0,0), defaultStarringTime),
        new TransitionShot(1), // go in the dark 
        new PositionShot(sun8P + new Vector3(550,0,0), sun8P + new Vector3(0,0,0), defaultStarringTime),
        new TransitionShot(0),   
       

       

     


    };




    static public List<string> sunsName = new List<string>(
        new string[] { "Sun1", "Sun2", "Sun3", "Sun4", "Sun5", "Sun6", "Sun7", "Sun8", }
        );

    

    

}
