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

    public void Motion()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out motionLayer);
        motionLayer.intensity.value += multiplyFx;
    }
}
