using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioAnalyzer1 : MonoBehaviour
{

    AudioSource audioSource = null;


    public int samplesSize;
    public float[] tempSamples;

    public float currentGlobalMagnitude = -1;
    public float magnitudeAmplifier = 0;
    public float minMagnitude = 1;

    public float velocityFactor = 1 ;
    public float baseVelocity = 0.5f; 
    public float emissionFactor = 1; 

    public ParticlesController particlesC;

    private float nextValue = 0;
    


    // Use this for initialization
    void Start()
    {

        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("", true, 1024, 44100); // FIXEME: need infinty
        audioSource.Play();

        tempSamples = new float[samplesSize];
        

    }


    void Update()
    {
        
        audioSource.GetSpectrumData(tempSamples, 0, FFTWindow.Blackman);
        currentGlobalMagnitude = 0; 
        foreach (float s in tempSamples)
        {
            currentGlobalMagnitude += s * magnitudeAmplifier;
        }
        particlesC.ChangeVelocity(baseVelocity + velocityFactor * currentGlobalMagnitude);
        particlesC.ChangeEmmision(emissionFactor * currentGlobalMagnitude);


    }



}
