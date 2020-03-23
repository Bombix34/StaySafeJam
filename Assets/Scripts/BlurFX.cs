using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlurFX : MonoBehaviour
{
    public GameObject globalVolume;
    public float fxSpeed = 2f;
    public float maxDof = 0.1f;

    Volume volume;
    DepthOfField dofLayer = null;
    float time;
    bool increased;
    bool launchBlur;
    float minDof;

    public void Blur()
    {
        time = 0;
        increased = false;
        launchBlur = true;
    }

    private void Start()
    {
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out dofLayer);

        minDof = dofLayer.focusDistance.value;
    }

    private void Update()
    {
        if (launchBlur)
        {
            time = Mathf.Clamp(time, 0, 1);
            dofLayer.focusDistance.value = Mathf.Lerp(minDof, maxDof, time);

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
