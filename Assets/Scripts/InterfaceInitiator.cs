using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InterfaceInitiator : MonoBehaviour {

    public float sliderValues = 1;
    public bool toggleValues = true; 

	// Use this for initialization
	void Start () {

        Slider[] sliders = FindObjectsOfType<Slider>();
        foreach(Slider slider in sliders)
        {

            slider.value = sliderValues+1; // tricks to have the event onvaluechanged trigger each time
            slider.value = sliderValues;
            Debug.Log("slider " + slider.name + " set to " + sliderValues);

        }

        Toggle[] toggles = FindObjectsOfType<Toggle>();
        foreach(Toggle toggle in toggles)
        {
            toggle.isOn = !toggleValues; // tricks to have the event onvaluechanged trigger each time
            toggle.isOn = toggleValues;
            Debug.Log("toggle " + toggle.name + " set to " + toggleValues);
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
