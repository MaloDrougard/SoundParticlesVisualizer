using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptMerger : MonoBehaviour {

    public AutoCameraScript autoCam = null;
    public ManualCameraScript manualCam = null;



	// Use this for initialization
	void Start () {

        this.CheckDependencies();
        autoCam.Pause(); 
	}
	
	// Update is called once per frame
	void Update () {

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



        
    }


    public void CheckDependencies()
    {

        if( autoCam == null)
        {
            Debug.LogWarning("CAMERASCRIPTMERGER: autoCam not set!"); 
        }

        if (manualCam == null)
        {
            Debug.LogWarning("CAMERASCRIPTMERGER: manualCam not set!");
        }


    }
}
