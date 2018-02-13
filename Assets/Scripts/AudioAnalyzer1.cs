using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioAnalyzer1 : MonoBehaviour
{

    AudioSource audioSource = null;


    public int samplesSize;
    public float[] tempSamples;

    public float currentGlobalMagnitude;
    public float magnitudeAmplifier;
    public float minMagnitude;


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
        particlesC.ChangeVelocity(currentGlobalMagnitude);
        particlesC.ChangeEmmision(currentGlobalMagnitude);


    }



}
