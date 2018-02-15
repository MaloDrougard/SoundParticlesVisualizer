using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This class allows this applicartion to have multiple display (physical monitor) 
/// </summary>
public class EnableDisplay : MonoBehaviour {


    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if one additional display is available and activate it.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
      
    }
}
