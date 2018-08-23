using System.Collections;
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
