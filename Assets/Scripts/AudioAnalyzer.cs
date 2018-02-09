using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioAnalyzer : MonoBehaviour {

    AudioSource audioSource = null;
    public float[] samples;
    public int samplesSize = 512;

    public Transform dancerPrefabT = null;
    public Dancer[] dancers;


	// Use this for initialization
	void Start () {

        audioSource = this.GetComponent<AudioSource>();
        samples = new float[samplesSize];
        dancers = new Dancer[samplesSize];

        Dancer dancerPrefab = dancerPrefabT.GetComponent<Dancer>();
        if( dancerPrefab == null)
        {
            Debug.LogError("AUDIOANALYZER: dancerPrefabT does not contains Dancer script!");
        }

        Vector3 tempPostion = Vector3.zero;
        Quaternion tempRotation = Quaternion.Euler(Vector3.zero);

        for( int i = 0; i < samplesSize; i++)
        {
            tempRotation = Quaternion.Euler(0, 0, i * 360 / samplesSize); 
            dancers[i] = CreateDancer(tempPostion, tempRotation);

        }

    }
	
    private Dancer CreateDancer(Vector3 position, Quaternion rotation)
    {
        Transform newDancerT = Instantiate(dancerPrefabT);
        newDancerT.SetParent(this.transform);
        newDancerT.transform.position = position;
        newDancerT.transform.rotation = rotation; 

        return newDancerT.GetComponent<Dancer>(); 
    }

	// Update is called once per frame
	void Update () {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

      
        for( int i = 0; i < samplesSize; i++)
        {
            dancers[i].SetAmplitude(samples[i] * 20 + 0.1f); 
        }
	}
    
}
