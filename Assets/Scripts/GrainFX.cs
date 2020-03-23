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

    private void Start()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out grainLayer);
    }

    public void Grain()
    {
        grainLayer.intensity.value += multiplyFx;
    }
}
