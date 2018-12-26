using System.Collections;
using System.Collections.Generic;
using UnityEngine;





/// <summary>
/// Rotate the camera in the direction point by the cursor
/// 
/// </summary>
public class DirectionCameraScript : MonoBehaviour {

    public Transform cam = null;

    public float rotationSpeed = 0.2f; 
    // if it set to true the mouse move relativly to center otherwhise it move from relativly to the first click
    public bool RelativeToScreenCenter = false;
    private Vector3 mouseDeltaOrigin = new Vector3(Screen.width / 2, Screen.height / 2, 0);


    // Use this for initialization
    void Start () {
        this.CheckDependencies(); 
		
	}
	
	// Update is called once per frame
	void Update () {


                // Mouse control

                // set the origin of delta
                if (Input.GetMouseButtonDown(0))
                {
                    if (RelativeToScreenCenter)
                    {
                        mouseDeltaOrigin = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                    }
                    else
                    {
                       mouseDeltaOrigin = Input.mousePosition;
                    }

                }

                // rotation initiate by the mouse
                if (Input.GetMouseButton(0))
                {
                    var position = Input.mousePosition;
                    var delta = position - mouseDeltaOrigin;

                    this.cam.transform.Rotate(new Vector3(-1, 0, 0), delta.y * Time.deltaTime * rotationSpeed, Space.Self); // vertical rotation is relative to its self
                    this.cam.transform.Rotate(new Vector3(0, 1, 0), delta.x * Time.deltaTime * rotationSpeed, Space.World);  // horizontal rotation is relative to world
               
                }


            }

    public void CheckDependencies()
    {
        if(cam == null)
        {
            Debug.LogWarning("DIRECTIONCAMERASCRIPT: cam is null"); 
        }
    }




}
