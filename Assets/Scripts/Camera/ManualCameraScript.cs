using System.Collections;
using System.Collections.Generic;
using UnityEngine;





/// <summary>
/// Camera translation controler
/// 
/// </summary>

public class ManualCameraScript : MonoBehaviour {

    
    public float panSpeed = 10f;
    public Transform cam = null;
    

    // once the script do an action on motion this bool switch to true,
    // and it can be reset to false only by SetIsPiliot(false)
    public bool isPilot = false;
    



    private void Start()
    {
        this.CheckDependencies();
        isPilot = false; 
     
    }


    // Update is called once per frame
    void Update () {
        bool isMoving = false;
       
  
        // global translation
        Vector3 move = new Vector3(0, 0, 0);

        if (Input.GetButton("Z"))
        {
            move.z += Input.GetAxis("Z") * panSpeed * Time.deltaTime;
            isMoving = true;

        }

        if( Input.GetButton("X"))
        {
            move.x += Input.GetAxis("X") * panSpeed * Time.deltaTime;
            isMoving = true;
        }


        if (Input.GetButton("Y"))
        {
            move.y += Input.GetAxis("Y") * panSpeed * Time.deltaTime;
            isMoving = true;
        }



        if (isMoving)
        {
            isPilot = true; 
        }
        move = cam.TransformVector(move); // move in the object space
        this.transform.position = this.transform.position + move;

    }

    

    public void ResetRotation()
    {
        // allign the rotation to the parent one
        cam.transform.rotation = this.transform.rotation   ;
  
    }


    public void SetIsPilot(bool value)
    {
        isPilot = value; 
    }

    public void CheckDependencies()
    {

        if (cam == null)
        {
            Debug.Log("MYCAMERACONTROLER2: camera is not set");
        }


    }


}

