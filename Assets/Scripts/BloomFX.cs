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

    private void Start()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out bloomLayer);
    }

    public void Bloom()
    {
        bloomLayer.dirtIntensity.value = Mathf.Clamp(bloomLayer.dirtIntensity.value, 0, 1000);
        bloomLayer.dirtIntensity.value += multiplyFx;
    }
}
