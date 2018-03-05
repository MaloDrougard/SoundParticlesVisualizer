using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioAnalyzer1 : MonoBehaviour
{

    AudioSource audioSource = null;


    public int samplesSize;
    public float[] tempSamples;


    public bool useStaticVelocity = false;
    public bool useStaticEmission = false;
    public bool useStaticSize = false;


    // used when relative to sound is used
    public float globalVelocityFactor = 1;
    public float globalEmissionFactor = 1;
    public float globalSizeFactor = 1;

    // used when static is used
    public float globalVelocityStatic = 1;
    public float globalSizeStatic = 1;
    public float globalEmissionStatic = 1;


    public List<string> sunsName = new List<string>(
        new string[] { "Sun1", "Sun2", "Sun3", "Sun4", "Sun5", "Sun6", "Sun7", "Sun8", });

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

    // collect the values used by the particules system 
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
            p.ChangeSize(globalSizeStatic);
        }

    }


    private void SetSunsEmissionStatic()
    {
        foreach (ParticlesController p in sunsSystems.Values)
        {
            p.ChangeEmision(globalEmissionStatic);
        }

    }


    private void SetSunsVelocityStatic()
    {
        foreach (ParticlesController p in sunsSystems.Values)
        {
            p.ChangeVelocity(globalVelocityStatic);
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
            newValue = globalSizeFactor * soundCapters[ sunsToValues[p.Key] ];
            p.Value.ChangeSize( newValue );
        }
    }


    private void SetSunsVelocityRelativeToSound()
    {


        float newValue = 0;
        foreach (var p in sunsSystems)
        {
            newValue = globalSizeFactor * soundCapters[sunsToValues[p.Key]];
            p.Value.ChangeVelocity(newValue);

        }
    }


    private void SetSunsEmissionRelativeToSound()
    {

        float newValue = 0;
        foreach (var p in sunsSystems)
        {
            newValue = globalSizeFactor * soundCapters[sunsToValues[p.Key]];
            p.Value.ChangeEmision(newValue);
        }
    }





}
