using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomFX : MonoBehaviour
{
    public float multiplyFx = 0.05f;
    public GameObject globalVolume;

    Volume volume;
    Bloom bloomLayer = null;

    public void Bloom()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out bloomLayer);
        bloomLayer.dirtIntensity.value = Mathf.Clamp(bloomLayer.dirtIntensity.value, 0, 1000);
        bloomLayer.dirtIntensity.value += multiplyFx;
    }
}
