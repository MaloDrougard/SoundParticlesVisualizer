using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsManager : MonoBehaviour {

    public Dictionary<string, ParticlesController> sunsSystems = new Dictionary<string, ParticlesController>();

    public Dictionary<string, Color> namesColors = new Dictionary<string, Color>();

    public ColorPanel globalColorPanel;

    public GradientCreator gradientCreator = new GradientCreator();


    // Use this for initialization
    void Start () {

        namesColors.Add("red", Color.red);
        namesColors.Add("blue", Color.blue);
        namesColors.Add("green", Color.green);
        namesColors.Add("vertLucioles", Color.HSVToRGB(120 / 359f, 111 / 255f, 189 / 255f));

        GameObject finded = null;
        foreach (string name in Settings.sunsName)
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

        globalColorPanel.dropColorA.ClearOptions();
        globalColorPanel.dropColorB.ClearOptions();

        globalColorPanel.dropColorA.AddOptions(new List<string>(namesColors.Keys)) ;
        globalColorPanel.dropColorB.AddOptions(new List<string>(namesColors.Keys));



    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetColorFromGlobalDrop()
    {
        string colorAName = globalColorPanel.dropColorA.options[globalColorPanel.dropColorA.value].text;
        string colorBName = globalColorPanel.dropColorB.options[globalColorPanel.dropColorB.value].text;

        Gradient gradient = gradientCreator.CreateGradientTwoColor(namesColors[colorAName], namesColors[colorBName]);
        ChangeColor(gradient);

    }



    public void ResetInitialColor()
    {
        foreach (var p in sunsSystems.Values)
        {
            p.ResetInitialColor();
        }
    }

    public void ChangeColor(Gradient gradient)
    {
        foreach (var p in sunsSystems.Values)
        {
            p.ChangeColor(gradient);
        }

    }


}
