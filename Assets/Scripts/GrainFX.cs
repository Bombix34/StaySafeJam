using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GrainFX : MonoBehaviour
{
    public float multiplyFx = 0.05f;
    public GameObject globalVolume;

    Volume volume;
    FilmGrain grainLayer = null;

    public void Grain()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out grainLayer);
        grainLayer.intensity.value += multiplyFx;
    }
}
