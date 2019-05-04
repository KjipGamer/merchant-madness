﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenerateColor : MonoBehaviour
{
    GameObject merchant;

    public List<Color32> greencolors;
    public List<Color32> redcolors;
    public List<Color32> bluecolors;
    public List<Color32> yellowcolors;

    


    public void Start() {
        greencolors = new List<Color32>
        {
            new Color32(0, 90, 0, 255),
            new Color32(0, 255, 0, 255)
        };

        redcolors = new List<Color32>
        {
            new Color32(90, 0, 0, 255),
            new Color32(255, 0, 0, 255)
        };

        bluecolors = new List<Color32>
        {
            new Color32(0, 0, 90, 255),
            new Color32(0, 0, 255, 255)
        };

        merchant = GameObject.Find(gameObject.name + "Entity");

        GenerateRandomColor();

    }

    public void GenerateRandomColor() {
        float colorval = Random.Range(0f, 1f);
        int color;

        if(gameObject.GetComponent<MerchantPrefab>().merchantcolor == 0)
        {
            color = Random.Range(1, 4);
        } else
        {
            color = gameObject.GetComponent<MerchantPrefab>().merchantcolor;
        }

        Debug.Log(color);

        if (color == 1)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(greencolors[0], greencolors[1], colorval);
        if (color == 2)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(redcolors[0], redcolors[1], colorval);
        if (color == 3)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(bluecolors[0], bluecolors[1], colorval);
    }
}


[CustomEditor(typeof(GenerateColor))]
public class ColorInspector : Editor {

    public GenerateColor gc;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        GenerateColor gc = (GenerateColor)target;

        if(GUILayout.Button("Generate Color"))
        {
            gc.Start();

        }
    }

}