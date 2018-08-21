using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This class allows this applicartion to have multiple display (physical monitor) 
/// </summary>
public class EnableDisplay : MonoBehaviour {

    public Camera mainCamera;
    public Canvas uiCanvas;
    public Camera uiCamera;

    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if one additional display is available and activate it.
        if (Display.displays.Length == 1)
            Debug.Log("Only one display detected");
        if (Display.displays.Length > 1)
        {
            Debug.Log("Two displays detected");
            Display.displays[1].Activate();
        }
        
    }

    public void SwitchDisplay()    
    {
        int display1 = mainCamera.targetDisplay ;
        int display2 = uiCamera.targetDisplay;

        mainCamera.targetDisplay = display2;
        uiCamera.targetDisplay = display1;
        uiCanvas.targetDisplay = display1;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchDisplay();
        }
    }



}
