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



    public Dictionary<string, ParticlesController> systems = new Dictionary<string, ParticlesController>();
    

    // use in UI 
    public SoundDrawer basicDrawer = null;

    

    // Use this for initialization
    void Start()
    {

        string search = "";
        GameObject finded = null; 
        for (int i = 1; i < 9; i++)
        {
            search = "Sun" + i; 
            finded = GameObject.Find(search);
            if(finded == null)
            {
                Debug.LogWarning("AUDIOANALYZER1: Start(): " + search + " gameobject not found!");

            }else
            {
                systems.Add(search, finded.GetComponent<ParticlesController>());
            }
            finded = null; 
        }

     
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("", true, 1024, 44100); // FIXEME: need infinty
        audioSource.Play();

        tempSamples = new float[samplesSize];

    }

    




    void Update()
    {
        
        audioSource.GetSpectrumData(tempSamples, 0, FFTWindow.Blackman);
        flatSoundSample(); 
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


    private  void flatSoundSample()
    {
        int modulo = ((samplesSize / 8) * 7);
        for (int i = 0; i <samplesSize; i++)
        {
            
            tempSamples[i] = ((i%modulo)+ 1)  * tempSamples[i % modulo ]; // we do not take realy high frequncy because never happend
        }
    }


    private void SetSunsSizeStatic()
    {
        ParticlesController p;
        string name = "";
        for (int i = 1; i < 9; i++)
        {
            name = "Sun" + i;
            p = systems[name];

            p.ChangeSize(globalSizeStatic);
        }

    }


    private void SetSunsEmissionStatic()
    {
        ParticlesController p;
        string name = "";
        for (int i = 1; i < 9; i++)
        {
            name = "Sun" + i;
            p = systems[name];

            p.ChangeEmision(globalEmissionStatic);
        }

    }


    private void SetSunsVelocityStatic()
    {
        ParticlesController p;
        string name = "";
        for (int i = 1; i < 9; i++)
        {
            name = "Sun" + i;
            p = systems[name];

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

        ParticlesController p;
        string name = "";
        for (int i = 1; i < 9; i++)
        {
            name = "Sun" + i;
            p = systems[name];

            float value = 0;
            for (int w = (i - 1) * samplesSize / 8; w < ((i - 1) * samplesSize / 8) + 8; w++)
            {
                value = tempSamples[w];
            }

            p.ChangeSize(globalSizeFactor * value);

        }
    }


    private void SetSunsVelocityRelativeToSound()
    {

        ParticlesController p;
        string name = ""; 
        for ( int i = 1; i < 9; i++)
        {
            name = "Sun" + i; 
            p = systems[name];

            float value = 0;
            for (int w = (i-1) * samplesSize/8 ; w <  ((i-1) * samplesSize / 8) + 8; w++)
            {
                value = tempSamples[w];
            }

            p.ChangeVelocity(globalVelocityFactor * value);

        }
    }


    private void SetSunsEmissionRelativeToSound()
    {

        ParticlesController p;
        string name = "";
        for (int i = 1; i < 9; i++)
        {
            name = "Sun" + i;
            p = systems[name];

            float value = 0;
            for (int w = (i - 1) * samplesSize / 8; w < ((i - 1) * samplesSize / 8) + 8; w++)
            {
                value = tempSamples[w];
            }

            p.ChangeEmision(globalEmissionFactor * value);

        }
    }





}
