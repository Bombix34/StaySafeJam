using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DistortionBumper : MonoBehaviour
{
    public GameObject globalVolume;
    public float fxSpeed = 2f;
    public float maxDistortion = 0.1f;

    Volume volume;
    LensDistortion lensLayer = null;
    float time;
    bool increased;
    bool launchBlur;
    float minDistortion;

    public void DistBump()
    {
        time = 0;
        increased = false;
        launchBlur = true;
    }

    private void Start()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out lensLayer);

        minDistortion = lensLayer.intensity.value;
    }

    private void Update()
    {
        if (launchBlur)
        {
            time = Mathf.Clamp(time, 0, 1);
            lensLayer.intensity.value = Mathf.Lerp(minDistortion, minDistortion - maxDistortion, time);

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
                minDistortion = time <= 0 ? lensLayer.intensity.value : minDistortion;
            }
        }
    }
}
