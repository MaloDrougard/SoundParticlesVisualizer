using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

/// <summary>
/// This objest is used to set all sliders at once and to be able to create slider configuration;
/// Fot the moment all the sliders and toggles of the interfaces are set and save even if you add a new one :) 
/// Be care full, the values and the sliders are mapped by list!
/// </summary>
public class SliderManager : MonoBehaviour {



    List<Slider> sliders = new List<Slider>();
    List<Toggle> toggles = new List<Toggle>();

    public Dictionary<string, SlidersConfig> configs = new Dictionary<string, SlidersConfig>();

    InputField saveConfigNameInput;
    Dropdown loadConfigDropdown; 


    // Use this for initialization
    void Start() {
        Debug.LogWarning("slfdafdfasdfdsfsd");


        SlidersConfig initConfig = new SlidersConfig();
        initConfig.configName = "init";
        initConfig.slidersValue = new List<float>() { 0.8f, 0.8f, 0.8f, 0.8f, 0.8f, 0.8f, 0.8f, };
        configs.Add(initConfig.configName, initConfig);

        sliders = new List<Slider>(FindObjectsOfType<Slider>());
        toggles = new List<Toggle>(FindObjectsOfType<Toggle>());

        saveConfigNameInput = GameObject.Find("InputFieldSaveSlidersConfig").GetComponent<InputField>();
        loadConfigDropdown = GameObject.Find("DropdownLoadSlidersConfig").GetComponent<Dropdown>(); 

        SetConfig("init");
    }

    public void SetLoadDropDown()
    {
        loadConfigDropdown.ClearOptions();
        loadConfigDropdown.AddOptions(new List<string>(configs.Keys));
    }

    public void LoadConfig()
    {
        string name = loadConfigDropdown.options[loadConfigDropdown.value].text; ;
        SetConfig(name);
    }

    public void SetConfig(string name)
    {
        SlidersConfig config = configs[name];
        for (int i = 0; i < sliders.Count; i++)
        {
            sliders[i].value = config.slidersValue[i];
        }
    }

    public void SaveConfig()
    {
        Debug.LogWarning(saveConfigNameInput.text);
        SaveConfig(saveConfigNameInput.text); 
        
    }

    public void SaveConfig(string name)
    {
        SlidersConfig newConfig = new SlidersConfig();
        newConfig.configName = name;
        for (int i = 0; i < sliders.Count; i++)
        {
            newConfig.slidersValue.Add(sliders[i].value);
        }
        configs.Add(newConfig.configName, newConfig);
        SetLoadDropDown(); // to update the display; 
    }

}



[Serializable]

public class SlidersConfig
{
    public string configName = "notSet"; 
    public List<float> slidersValue = new List<float>();
    public List<bool> togglesValue = new List<bool>(); 
}