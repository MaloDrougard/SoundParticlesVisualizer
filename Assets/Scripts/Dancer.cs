using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour {


    private float width = 0.1f;
    private float height = 0.1f;
    private float deep = 0.01f;


    public float GetWidth()
    {
        return width;
    }


    public void SetWidth(float newWidth)
    {
        this.width = newWidth;
        Vector3 newLocalScale = this.transform.localScale;
        newLocalScale.x = width;
        this.transform.localScale = newLocalScale;

    }

    public float GetDeep() {
        return deep;
    }


    public void SetDeep(float newDeep)
    {
        this.deep = newDeep;
        Vector3 newLocalScale = this.transform.localScale;
        newLocalScale.z = deep;
        this.transform.localScale = newLocalScale;

    }


    public void SetHeight(float newHeight)
    {
        height = newHeight;
        Vector3 newLocalScale = this.transform.localScale;
        newLocalScale.y = height;
        this.transform.localScale = newLocalScale;
        Vector3 newPosition = this.transform.position;
        newPosition.y = height / 2f;
        this.transform.position = newPosition; 
    }

    public float GetHeight()
    {
        return height;
    }

	// Use this for initialization
	void Start () {
        SetWidth(this.width);
        SetDeep(deep); 
	}
	


	// Update is called once per frame
	void Update () {
		
	}
}
