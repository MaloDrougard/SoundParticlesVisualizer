using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour {

    public float amplitude = 0; 
    public Transform movingComponentT = null;

    // border of the circle (assuming that the object has no height)
    private Vector3 originalLocalPosition;  

    public void Start()
    {

        originalLocalPosition = movingComponentT.transform.localPosition;
        SetAmplitude(0.1f);  // to have the correct positioning
    }



    public void SetAmplitude(float ampli)
    {
        Vector3 scale = movingComponentT.localScale;
        scale.y = ampli;
        movingComponentT.localScale = scale;

        movingComponentT.localPosition = originalLocalPosition + new Vector3(ampli / 2f, 0, 0);  
    }

 
}
