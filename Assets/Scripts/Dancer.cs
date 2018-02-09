using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour {

    public float amplitude = 0; 
    public Transform movingComponentT = null;

    // border of the circle (assuming that the object has no height)
    public Vector3 baseLocalPosition;  

    public void SetBAseLocalPosition(Vector3 basePos)
    {
        baseLocalPosition = basePos;
        movingComponentT.transform.localPosition = baseLocalPosition;
    }



    public void SetDoubleAmplitude(float ampli)
    {
        Vector3 scale = movingComponentT.localScale;
        scale.y = ampli;
        movingComponentT.localScale = scale;

      
    }

    public void SetAmplitude(float ampli)
    {
        Vector3 scale = movingComponentT.localScale;
        scale.y = ampli;
        movingComponentT.localScale = scale;

        movingComponentT.localPosition = baseLocalPosition + new Vector3(ampli / 2f, 0, 0);  
    }

 
}
