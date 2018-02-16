using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioAnalyzer1 : MonoBehaviour
{

    AudioSource audioSource = null;


    public int samplesSize;
    public float[] tempSamples;
   

    public float globalVelocityFactor = 1;
    public float globalEmissionFactor = 1;




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

        UpdateBasicDrawer();
        UpdateAllSuns(); 


    }

    private void UpdateBasicDrawer()
    {
        if (basicDrawer != null)
        {
            basicDrawer.DisplaySamples(tempSamples);
        }
    }


    private void UpdateAllSuns()
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
            Debug.Log(name +" velo " + globalVelocityFactor* value);
            Debug.Log(name + " Emission " + globalEmissionFactor * value);
            p.ChangeVelocity(globalVelocityFactor * value);
            p.ChangeVelocity(globalEmissionFactor * value);


        }


    }


    //private void UpdateSun1()
    //{
    //    ParticlesController p = systems["Sun1"];

    //    float v = 0;
    //    for (int i = 0; i < 8; i++)
    //    {
    //        v = tempSamples[i];
    //    }
        
    //    p.ChangeVelocity(globalVelocityFactor  * v);
    //    p.ChangeEmmision(globalEmissionFactor * v);
    //}


    //private void UpdateSun2()
    //{
    //    ParticlesController p = systems["Sun2"];

    //    float v = 0;
    //    for (int i = 7; i < 16; i++)
    //    {
    //        v = tempSamples[i];
    //    }

    //    p.ChangeVelocity(globalVelocityFactor * v);
    //    p.ChangeEmmision(globalEmissionFactor * v);

    //}




}
