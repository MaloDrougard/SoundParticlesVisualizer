using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

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


    public void ChangeColor()
    {
        foreach (var p in sunsSystems.Values)
        {
            p.ChangeColor();
        }

    }

    // end GUI functions *********************************************


    public List<string> sunsName = new List<string>(
        new string[] { "Sun1", "Sun2", "Sun3", "Sun4", "Sun5", "Sun6", "Sun7", "Sun8", });

    // Map from sun name to capters index
    public Dictionary<string, int> sunsToValues = new Dictionary<string, int>() {
        
        {"Sun1", 1},
        {"Sun5", 2},

        {"Sun2", 2},
        {"Sun6", 3},

        {"Sun3", 3},
        {"Sun7", 4},

        {"Sun4", 4},        
        {"Sun8", 5}
    };

    public Dictionary<string, ParticlesController> sunsSystems = new Dictionary<string, ParticlesController>();

    // collect the frequency values done by the sound 
    // the values are derived from the tempSamples
    public float[] soundCapters = new float[8];

    // Maximal possible frequency
    float fMax = 0;

    // use in UI 
    public SoundDrawer samplesDrawer = null;
    public SoundDrawer captersDrawer = null;

    float[] captersDrawerValues = null;

    // Use this for initialization
    void Start()
    {
     
        if (soundCapters != null)
        {
            captersDrawer.Init(6);
            captersDrawerValues = new float[6];
        }
        if(samplesDrawer != null)
        {
            samplesDrawer.Init(samplesSize); 
        }


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
        audioSource.clip = Microphone.Start("", true, 100, 48000); // FIXEME: need infinty
        audioSource.Play();

        fMax = AudioSettings.outputSampleRate / 2;
        Debug.Log(fMax);

        tempSamples = new float[samplesSize];


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
       

        soundCapters[0] = 10 * BandVol(1, 120); // not used
        soundCapters[1] = 10 * BandVol(120, 300);
        soundCapters[2] = 10 * BandVol(300, 800);
        soundCapters[3] = 10 * BandVol(800, 1500);
        soundCapters[4] = 10 * BandVol(1500, 4000);
        soundCapters[5] = 13 * BandVol(4000, 8000);
        soundCapters[6] = 13* BandVol(8000, fMax); // not used
        soundCapters[7] = BandVol(0, fMax);



    }


    float BandVol(float fLow, float fHigh){
 
     fLow = Mathf.Clamp(fLow, 20, fMax); // limit low...
     fHigh = Mathf.Clamp(fHigh, fLow, fMax); // and high frequencies

     int n1 = (int) Mathf.Floor(fLow / fMax * (float) samplesSize );
     int n2 = (int) Mathf.Floor(fHigh / fMax  * (float) samplesSize );
     float sum = 0;

     // average the volumes of frequencies fLow to fHigh
     for (var i=n1; i<=n2-1; i++){
         sum += tempSamples[i];
     }
        return sum; // (n2 - n1 + 1);
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
        if (samplesDrawer != null)
        {
            samplesDrawer.DisplaySamples(tempSamples);
        }
        if (captersDrawer != null)
        {
       
            Array.Copy(soundCapters, 1, captersDrawerValues, 0, 6);
            captersDrawer.DisplaySamples(captersDrawerValues) ;
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
