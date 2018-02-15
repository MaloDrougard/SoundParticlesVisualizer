using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioAnalyzer : MonoBehaviour {

    AudioSource audioSource = null;
    public float[] tempSamples;

    public int samplesSize ;
    public float rotationStep;
    public float magnitudeAmplifier;
    public float minMagnitude;
    public int numberOfCircles;
    public float circleStep;

    public Transform dancerPrefabT = null;
    List<Transform> circles;






    // Use this for initialization
    void Start () {

        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("", true, 120, 44100);
        audioSource.Play();

        circles = new List<Transform>();
        tempSamples = new float[samplesSize]; 

        Dancer dancerPrefab = dancerPrefabT.GetComponent<Dancer>();
        if( dancerPrefab == null)
        {
            Debug.LogError("AUDIOANALYZER: dancerPrefabT does not contains Dancer script!");
        }

        Vector3 tempPostion = Vector3.zero;
        Quaternion tempRotation = Quaternion.Euler(Vector3.zero);
        


    }

    private Transform CreateCircle(float[] samples )
    {
        Transform circleT = new GameObject().transform;
        circleT.SetParent(this.transform);
        
        Vector3 tempPostion = Vector3.zero;
        Quaternion tempRotation = Quaternion.Euler(Vector3.zero);

        for (int i = 0; i < samples.Length ; i++)
        {
            tempRotation = Quaternion.Euler(0, 0, i * 360f / (float)samplesSize);
            CreateDancer(tempPostion, tempRotation, circleT, samples[i] * magnitudeAmplifier + minMagnitude );
        }

        return circleT; 

    }

    private Dancer CreateDancer(Vector3 position, Quaternion rotation, Transform parent, float ampli)
    {
        Transform newDancerT = Instantiate(dancerPrefabT);
        newDancerT.SetParent(parent);
        newDancerT.transform.position = position;
        newDancerT.transform.rotation = rotation;

        Dancer dancer = newDancerT.GetComponent<Dancer>();
        dancer.SetBAseLocalPosition(new Vector3(-10, 0, 0));
        dancer.SetDoubleAmplitude(ampli); 

        return newDancerT.GetComponent<Dancer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (circles.Count >= numberOfCircles)
        {
            Transform c = circles[0];
            circles.RemoveAt(0);
            Destroy(c.gameObject);
        }

        foreach (Transform c in circles)
        {
            c.position += new Vector3(0, 0, circleStep);
          
            c.Rotate(new Vector3(0, 0, rotationStep * 360f / (float)samplesSize));
        }

        audioSource.GetSpectrumData(tempSamples, 0, FFTWindow.Blackman);
        Transform newCircle = CreateCircle(tempSamples);
        circles.Add(newCircle);
    }
    
}
