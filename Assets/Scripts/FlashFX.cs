using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FlashFX : MonoBehaviour
{
    public GameObject globalVolume;
    public float fxSpeed = 2f;
    public float maxFlash = 2f;

    Volume volume;
    ColorAdjustments colorLayer = null;
    float time;
    bool increased;
    bool launchBlur;

    public void Flash()
    {
        time = 0;
        increased = false;
        launchBlur = true;
    }

    private void Start()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out colorLayer);
    }

    private void Update()
    {
        if (launchBlur)
        {
            volume = globalVolume.GetComponent<Volume>();
            volume.profile.TryGet(out colorLayer);

            time = Mathf.Clamp(time, 0, 1);
            colorLayer.postExposure.value = Mathf.Lerp(0, maxFlash, time);

            if (!increased)
            {
                time += Time.deltaTime * fxSpeed;
                increased = time >= 1 ? true : false;
            }

            else
            {
                time -= Time.deltaTime * fxSpeed;
                increased = time <= 0 ? false : true;
                launchBlur = time <= 0 ? false : true;
            }
        }
    }
}
