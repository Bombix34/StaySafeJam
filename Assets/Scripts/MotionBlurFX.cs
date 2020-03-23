using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MotionBlurFX : MonoBehaviour
{
    public float multiplyFx = 0.05f;
    public GameObject globalVolume;

    Volume volume;
    MotionBlur motionLayer = null;

    private void Start()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out motionLayer);
    }

    public void Motion()
    {
        motionLayer.intensity.value += multiplyFx;
    }
}
