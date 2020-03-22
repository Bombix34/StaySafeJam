﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Distorsion : MonoBehaviour
{
    public float multiplyFx = 0.05f;
    public GameObject globalVolume;

    Volume volume;
    LensDistortion distorsionLayer = null;
    float baseValue;

    public void Distortion()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out distorsionLayer);
        distorsionLayer.intensity.value -= multiplyFx;
    }
}
