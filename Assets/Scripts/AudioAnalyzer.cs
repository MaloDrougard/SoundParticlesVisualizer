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
        Vector3 increment = new Vector3(dancerPrefab.GetWidth(), dancerPrefab.GetHeight()/2f , 0);
        for( int i = 0; i < samplesSize; i++)
        {
            dancers[i] = CreateDancer(tempPostion);
            tempPostion += increment;
        }

    }
	
    private Dancer CreateDancer(Vector3 position)
    {
        Transform newDancerT = Instantiate(dancerPrefabT);
        newDancerT.SetParent(this.transform);
        newDancerT.transform.position = position;

        return newDancerT.GetComponent<Dancer>(); 
    }

	// Update is called once per frame
	void Update () {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

      
        for( int i = 0; i < samplesSize; i++)
        {
            dancers[i].SetHeight(samples[i] * 10 + 0.1f); 
        }
	}
    
}
