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



    // register for the particles system
    public Dictionary<string, ParticlesController> sunsSystems = new Dictionary<string, ParticlesController>();


    // collect the frequency values done by the sound 
    // the values are derived from the tempSamples
    // and used by the particles systems
    public float[] soundCaptersInUse = new float[8];  
    public float[] soundCaptersRaw = new float[8];
    public float[] soundCaptersPrevious = new float[8];  
    public float[] soundCaptersAverage = new float[8];  // use to smooth the transition
    

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


    // Maximal possible frequency
    float fMax = 0;

    // use in UI  (lines )
    public SoundDrawer samplesDrawer = null;
    public SoundDrawer captersDrawer = null;
    float[] captersDrawerValues = null;



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


    // GUI functions, end ***************************



    // Use this for initialization
    void Start()
    {
     
        if (soundCaptersInUse != null)
        {
            captersDrawer.Init(6);
            captersDrawerValues = new float[6];
        }
        if(samplesDrawer != null)
        {
            samplesDrawer.Init(samplesSize); 
        }


        GameObject finded = null; 
        foreach (string name in Settings.sunsName)
        {
            
            finded = GameObject.Find(name);
            if (finded == null)
            {
                Debug.LogWarning("AUDIOANALYZER1: Start(): " + name + " gameobject not found!");
            }
            else{
                sunsSystems.Add(name, finded.GetComponent<ParticlesController>());
            }
            finded = null;
        }

        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("", true, 120, 48000); 
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


    private void SetSoundCapters()
    {
        soundCaptersPrevious = soundCaptersInUse;
        SetSoundCaptersRaw();
        SetSoundCaptersAverage();

        soundCaptersInUse = soundCaptersAverage; 

    }

    private void SetSoundCaptersAverage()
    {
        float percent = 0.2f; // percentage of the new value 
        soundCaptersAverage[0] = percent * soundCaptersRaw[0] + (1 - percent) * soundCaptersPrevious[0] ;
        soundCaptersAverage[1] = percent * soundCaptersRaw[1] + (1 - percent) *  soundCaptersPrevious[1];
        soundCaptersAverage[2] = percent * soundCaptersRaw[2] + (1 - percent) * soundCaptersPrevious[2];
        soundCaptersAverage[3] = percent * soundCaptersRaw[3] + (1 - percent) * soundCaptersPrevious[3];
        soundCaptersAverage[4] = percent * soundCaptersRaw[4] + (1 - percent) * soundCaptersPrevious[4];
        soundCaptersAverage[5] = percent * soundCaptersRaw[5] + (1 - percent) * soundCaptersPrevious[5];
        soundCaptersAverage[6] = percent * soundCaptersRaw[6] + (1 - percent) * soundCaptersPrevious[6];
        soundCaptersAverage[7] = percent * soundCaptersRaw[7] + (1 - percent) * soundCaptersPrevious[7];
    }

    private  void SetSoundCaptersRaw()
    {
        soundCaptersRaw[0] = 10 * BandVol(1, 120); // not used
        soundCaptersRaw[1] = 10 * BandVol(120, 300);
        soundCaptersRaw[2] = 10 * BandVol(300, 800);
        soundCaptersRaw[3] = 10 * BandVol(800, 1500);
        soundCaptersRaw[4] = 10 * BandVol(1500, 4000);
        soundCaptersRaw[5] = 13 * BandVol(4000, 8000);
        soundCaptersRaw[6] = 13* BandVol(8000, fMax); // not used
        soundCaptersRaw[7] = BandVol(0, fMax);
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
       
            Array.Copy(soundCaptersInUse, 1, captersDrawerValues, 0, 6);
            captersDrawer.DisplaySamples(captersDrawerValues) ;
        }

    }


    private void SetSunsSizeRelativeToSound()
    {
        float newValue = 0;
        foreach (var p in sunsSystems)
        {
            newValue = globalDynamicSize * soundCaptersInUse[ sunsToValues[p.Key] ];
            p.Value.ChangeSize( newValue );
        }
    }


    private void SetSunsVelocityRelativeToSound()
    {
        float newValue = 0;
        foreach (var p in sunsSystems)
        {
            newValue = globalDynamicVelocity * soundCaptersInUse[sunsToValues[p.Key]];
            p.Value.ChangeVelocity(newValue);

        }
    }


    private void SetSunsEmissionRelativeToSound()
    {

        float newValue = 0;
        foreach (var p in sunsSystems)
        {
            newValue = globalDynamicEmission * soundCaptersInUse[sunsToValues[p.Key]];
            p.Value.ChangeEmision(newValue);

        }
    }




}
