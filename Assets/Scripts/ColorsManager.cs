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
        Color newColor = new Color();

        namesColors.Add("red", Color.red);
        namesColors.Add("magenta", Color.magenta);
        namesColors.Add("blue", Color.blue);
        namesColors.Add("cyan", Color.cyan);
        namesColors.Add("yellow", Color.yellow);
        namesColors.Add("green", Color.green);
        namesColors.Add("white", Color.white);

        ColorUtility.TryParseHtmlString("#b3ffd9", out newColor);
        namesColors.Add("vertClair", newColor);
        
        ColorUtility.TryParseHtmlString("#ff9933", out newColor);
        namesColors.Add("orange", newColor);


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
