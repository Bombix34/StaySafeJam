using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChromaticFX : MonoBehaviour
{
    public float multiplyFx = 0.05f;
    public GameObject globalVolume;

    Volume volume;
    ChromaticAberration chromaticLayer = null;

    public void Chroma()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out chromaticLayer);
        chromaticLayer.intensity.value += multiplyFx;
    }
}
