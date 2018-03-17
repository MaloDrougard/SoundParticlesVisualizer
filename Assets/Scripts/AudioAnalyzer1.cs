using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioAnalyzer1 : MonoBehaviour
{

    AudioSource audioSource = null;

    
    public int samplesSize;
    // strore samples from audio source 
    public float[] tempSamples;


    public bool useStaticVelocity = false;
    public bool useStaticEmission = false;
    public bool useStaticSize = false;


    // used when relative to sound is used
    public float globalDynamicVelocity = 1;
    public float globalDynamicEmission = 1;
    public float globalDynamicSize = 1;

    // used when static is used
    public float globalStaticVelocity = 1;
    public float globalStaticSize = 1;
    public float globalStaticEmission = 1;


    // GUI functions, use by sliders to set this object ***************************

    public void EnableStaticSize(Toggle toggle )
    {
        useStaticSize = toggle.isOn; 
    }


    public void EnableStaticVelocity(Toggle toggle)
    {
        useStaticVelocity = toggle.isOn;
    }


    public void EnableStaticEmission(Toggle toggle)
    {
        useStaticEmission = toggle.isOn;
    }



    public void SetStaticSize(Slider slider)
    { 
        this.globalStaticSize = RescaleExponential(slider.value);
    }

    public void SetDynamicSize(Slider slider)
    {        
        this.globalDynamicSize = RescaleExponential(slider.value);
    }

    public void SetStaticVelocity(Slider slider)
    {                            
        this.globalStaticVelocity = RescaleExponential(slider.value);
    }

    public void SetDynamicVelocity(Slider slider)
    {
        this.globalDynamicVelocity = RescaleExponential(slider.value);
    }

    public void SetStaticEmission(Slider slider)
    {
        this.globalStaticEmission = RescaleExponential(slider.value);
    }

    public void SetDynamicEmission(Slider slider)
    {
        this.globalDynamicEmission = RescaleExponential(slider.value);
    }

        
    public float RescaleExponential(float value)
    {
        return (Mathf.Pow(Settings.GoldenNumber, value) - 1);
    }
    // end GUI functions *********************************************


    public List<string> sunsName = new List<string>(
        new string[] { "Sun1", "Sun2", "Sun3", "Sun4", "Sun5", "Sun6", "Sun7", "Sun8", });

    // Map from sun name to capters index
    public Dictionary<string, int> sunsToValues = new Dictionary<string, int>() {
        
        {"Sun1", 0},
        {"Sun2", 1},
        {"Sun3", 2},
        {"Sun4", 3},
        {"Sun5", 4},
        {"Sun6", 5},
        {"Sun7", 4},
        {"Sun8", 0}
    };

    public Dictionary<string, ParticlesController> sunsSystems = new Dictionary<string, ParticlesController>();

    // collect the frequency values done by the sound 
    // the values are derived from the tempSamples
    public float[] soundCapters = new float[8]; 

    // use in UI 
    public SoundDrawer basicDrawer = null;

    

    // Use this for initialization
    void Start()
    {

        GameObject finded = null; 
        foreach (string name in sunsName)
        {
            
            finded = GameObject.Find(name);
            if (finded == null)
            {
                Debug.LogWarning("AUDIOANALYZER1: Start(): " + name + " gameobject not found!");

            }
            else
            {
                sunsSystems.Add(name, finded.GetComponent<ParticlesController>());
            }
            finded = null;
        }



     
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("", true, 100000, 44100); // FIXEME: need infinty
        audioSource.Play();

        tempSamples = new float[samplesSize];

        foreach(var p in sunsSystems.Values)
        {
            //p.ChangeColor(); 
        }

    }

    




    void Update()
    {
        
        audioSource.GetSpectrumData(tempSamples, 0, FFTWindow.Blackman);
        SetSoundCapters(); 
        UpdateBasicDrawer();

        if (useStaticSize)
        {
            SetSunsSizeStatic();
        } else
        {
            SetSunsSizeRelativeToSound();
        }

        if (useStaticEmission)
        {
            SetSunsEmissionStatic();
        }
        else
        {
            SetSunsEmissionRelativeToSound();
        }

        if (useStaticVelocity)
        {
            SetSunsVelocityStatic();   
        }
        else
        {
            SetSunsVelocityRelativeToSound();
        }
 
    }


    private  void SetSoundCapters()
    {
        int modulo = ((samplesSize / 8) * 7);
        
        // flat a little bit
        for (int i = 0; i <samplesSize; i++)
        {
            
            tempSamples[i] = (i + 1)  * tempSamples[i]; // we do not take realy high frequncy because never happend
        }

        for(int i = 0; i < 8; i++)
        {
            soundCapters[i] = 0; 
        }

        int n = 0;
        for (int j = 0; j < samplesSize; j++)
        {
            n = (int) Mathf.Floor(j / 8);
            soundCapters[ n ] += tempSamples[ j ];
        }

    }


    private void SetSunsSizeStatic()
    {
        foreach( ParticlesController p in sunsSystems.Values)
        {
            p.ChangeSize(globalStaticSize);
        }

    }


    private void SetSunsEmissionStatic()
    {
        foreach (ParticlesController p in sunsSystems.Values)
        {
            p.ChangeEmision(globalStaticEmission);
        }

    }


    private void SetSunsVelocityStatic()
    {
        foreach (ParticlesController p in sunsSystems.Values)
        {
            p.ChangeVelocity(globalStaticVelocity);
        }

    }


    private void UpdateBasicDrawer()
    {
        if (basicDrawer != null)
        {
            basicDrawer.DisplaySamples(tempSamples);
        }
    }


    private void SetSunsSizeRelativeToSound()
    {
        float newValue = 0;
        foreach (var p in sunsSystems)
        {
            newValue = globalDynamicSize * soundCapters[ sunsToValues[p.Key] ];
            p.Value.ChangeSize( newValue );
        }
    }




    private void SetSunsVelocityRelativeToSound()
    {


        float newValue = 0;
        foreach (var p in sunsSystems)
        {
            newValue = globalDynamicVelocity * soundCapters[sunsToValues[p.Key]];
            p.Value.ChangeVelocity(newValue);

        }
    }


    private void SetSunsEmissionRelativeToSound()
    {

        float newValue = 0;
        foreach (var p in sunsSystems)
        {
            newValue = globalDynamicEmission * soundCapters[sunsToValues[p.Key]];
            p.Value.ChangeEmision(newValue);

        }
    }




}
