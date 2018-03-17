using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings {

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

    static Vector3 centerP = (sun1P + sun4P + sun5P + sun8P )/4;
    
    static float defaultStarringTime = 10;
    static float defaultTransitionTime = 10;


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


        

        new PositionShot(centerP + new Vector3(0,0,-300) , centerP + new Vector3(0,0,60), 20),
        new TransitionShot(defaultTransitionTime),

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


    };






}
