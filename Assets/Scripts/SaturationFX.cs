using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SaturationFX : MonoBehaviour
{
    public float multiplyFx = 0.05f;
    public GameObject globalVolume;

    Volume volume;
    ColorAdjustments colorLayer = null;

    public void Saturation()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out colorLayer);
        colorLayer.saturation.value += multiplyFx;
    }
}
