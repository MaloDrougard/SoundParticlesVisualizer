/*
* Copyright (C) 2017-2019 Makem Corporation 
* 
* Created: 2018 Malo Drougard <malo.drougard@protonmail.com>
* 
* This file is part of SoundParticlesVisualizer (SPV).
* 
* SPV is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* any later version.
*
* SPV is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with SPV.  If not, see <https://www.gnu.org/licenses/>.
*
*/


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsManager : MonoBehaviour {

    public Dictionary<string, ParticlesController> sunsSystems = new Dictionary<string, ParticlesController>();


    public Dictionary<string, Dictionary<string, Gradient> > gradientsConfig = new Dictionary< string,  Dictionary<string, Gradient>>();
    
    
    public Dictionary<string, Color> namesColors = new Dictionary<string, Color>();

    public ColorPanel globalColorPanel; // for the two manual colors (gradient)

    public UnityEngine.UI.Dropdown dropdownConfig; 

    public GradientCreator gradientCreator = new GradientCreator();


    void InitColorPanel() // set names to colors
    {
        Color newColor = new Color();

        namesColors.Add("red", Color.red);

        namesColors.Add("yellow", Color.yellow);

        namesColors.Add("blue", Color.blue);

        namesColors.Add("green", Color.green);

        ColorUtility.TryParseHtmlString("#fd218e", out newColor);
        namesColors.Add("rose", newColor);

        namesColors.Add("magenta", Color.magenta);

        namesColors.Add("cyan", Color.cyan);

        ColorUtility.TryParseHtmlString("#fff3af", out newColor);
        namesColors.Add("jaune-clair", newColor);
       
        ColorUtility.TryParseHtmlString("#5bc7ff", out newColor); 
        namesColors.Add("bleu-clair", newColor); 

        namesColors.Add("white", Color.white);
        
    }


    void InitGradientsConfig()
    {
       


        Dictionary<string, Gradient> temp2Gradients = new Dictionary<string, Gradient>();
        temp2Gradients.Add("Sun1", gradientCreator.CreateGradientTwoColor(namesColors["jaune-clair"], namesColors["green"]));
        temp2Gradients.Add("Sun2", gradientCreator.CreateGradientTwoColor(namesColors["bleu-clair"], namesColors["green"]));
        temp2Gradients.Add("Sun3", gradientCreator.CreateGradientTwoColor(namesColors["jaune-clair"], namesColors["green"]));
        temp2Gradients.Add("Sun4", gradientCreator.CreateGradientTwoColor(namesColors["jaune-clair"], namesColors["green"]));
        temp2Gradients.Add("Sun5", gradientCreator.CreateGradientTwoColor(namesColors["bleu-clair"], namesColors["green"]));
        temp2Gradients.Add("Sun6", gradientCreator.CreateGradientTwoColor(namesColors["jaune-clair"], namesColors["green"]));
        temp2Gradients.Add("Sun7", gradientCreator.CreateGradientTwoColor(namesColors["bleu-clair"], namesColors["green"]));
        temp2Gradients.Add("Sun8", gradientCreator.CreateGradientTwoColor(namesColors["jaune-clair"], namesColors["green"]));
        gradientsConfig.Add("jaune-vert", temp2Gradients);


        Dictionary<string, Gradient> temp3 = new Dictionary<string, Gradient>();
        temp3.Add("Sun1", gradientCreator.CreateGradientTwoColor(namesColors["blue"], namesColors["white"]));
        temp3.Add("Sun2", gradientCreator.CreateGradientTwoColor(namesColors["rose"], namesColors["rose"]));
        temp3.Add("Sun3", gradientCreator.CreateGradientTwoColor(namesColors["rose"], namesColors["blue"]));
        temp3.Add("Sun4", gradientCreator.CreateGradientTwoColor(namesColors["blue"], namesColors["white"]));
        temp3.Add("Sun5", gradientCreator.CreateGradientTwoColor(namesColors["rose"], namesColors["red"]));
        temp3.Add("Sun6", gradientCreator.CreateGradientTwoColor(namesColors["blue"], namesColors["blue"]));
        temp3.Add("Sun7", gradientCreator.CreateGradientTwoColor(namesColors["rose"], namesColors["blue"]));
        temp3.Add("Sun8", gradientCreator.CreateGradientTwoColor(namesColors["blue"], namesColors["white"]));
        gradientsConfig.Add("blueSombre", temp3);


        Dictionary<string, Gradient> tempGradients = new Dictionary<string, Gradient>();
        tempGradients.Add("Sun1", gradientCreator.CreateGradientTwoColor(namesColors["bleu-clair"], namesColors["white"]));
        tempGradients.Add("Sun2", gradientCreator.CreateGradientTwoColor(namesColors["rose"], namesColors["rose"]));
        tempGradients.Add("Sun3", gradientCreator.CreateGradientTwoColor(namesColors["rose"], namesColors["rose"]));
        tempGradients.Add("Sun4", gradientCreator.CreateGradientTwoColor(namesColors["bleu-clair"], namesColors["white"]));
        tempGradients.Add("Sun5", gradientCreator.CreateGradientTwoColor(namesColors["bleu-clair"], namesColors["blue"]));
        tempGradients.Add("Sun6", gradientCreator.CreateGradientTwoColor(namesColors["bleu-clair"], namesColors["blue"]));
        tempGradients.Add("Sun7", gradientCreator.CreateGradientTwoColor(namesColors["rose"], namesColors["rose"]));
        tempGradients.Add("Sun8", gradientCreator.CreateGradientTwoColor(namesColors["bleu-clair"], namesColors["white"]));
        gradientsConfig.Add("Bleu-Rose", tempGradients);

    }



    // Use this for initialization
    void Start () {

        InitColorPanel(); 

        InitGradientsConfig(); 

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

        dropdownConfig.ClearOptions();
        dropdownConfig.AddOptions(new List<string>(gradientsConfig.Keys)); 
      
    }
    


    public void SetConfig()
    {

        string selectedConfig = dropdownConfig.options[dropdownConfig.value].text;

        foreach (var sg in gradientsConfig[selectedConfig])
        {
            sunsSystems[sg.Key].ChangeColor(sg.Value);
        }

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
