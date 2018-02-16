using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDrawer : MonoBehaviour {



    
    int samplesSize;
    public LineRenderer line = null;

    Vector3 baseHeight = new Vector3(0, 10, 0);
    Vector3 horizontalStep = new Vector3(0.1f, 0, 0);


	// Use this for initialization
	void Start () {
        Init(64); 
	}


    public void Init(int samplesSize)
    {
        this.samplesSize = samplesSize;

        line.positionCount = samplesSize; 
    }


    public void DisplaySamples(float[] samples)
    {
        int i = 0;
        foreach( float v in samples)
        {
            line.SetPosition(i, v * baseHeight + i * horizontalStep);
            i++;
         }
    }


}
