using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFX : MonoBehaviour
{
    public GameObject background;
    public int gradientState = 5;
    public int fuckedColors = 10;
    public float multiplyColor = 2f;
    public float maxColor = 0.85f;
    public float multiplyFX = 0.05f;

    int nbrEat;
    float colorBackground;
    float colors;
    Material material;

    void Start()
    {
        material = background.GetComponent<SpriteRenderer>().material;
        colors = 0.4f;
        colorBackground = 0;
        material.SetColor("_Color", new Color(colorBackground, colorBackground, colorBackground));
    }

    public void Background()
    {
        colorBackground += multiplyColor;
        colorBackground = Mathf.Clamp(colorBackground, 0, maxColor);
        material.SetColor("_Color", new Color(colorBackground, colorBackground, colorBackground));

        nbrEat += 1;
        if(nbrEat > gradientState && material.GetInt("_AddGradient") != 1)
        {
            material.SetInt("_AddGradient",1);
        }

        if(nbrEat > fuckedColors && material.GetInt("_Fuck") != 1)
        {
            material.SetInt("_Fuck", 1);
        }

        if(material.GetInt("_Fuck") == 1)
        {
            colors += multiplyFX;
            material.SetFloat("_FuckedUpColor", colors);
        }
    }
}
