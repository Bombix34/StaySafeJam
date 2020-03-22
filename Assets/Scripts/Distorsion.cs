using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Distorsion : MonoBehaviour
{
    LensDistortion distorsionLayer = null;
    float baseValue;
    public float multiplyFx = 0.05f;
    Volume volume;

    // Start is called before the first frame update
    void Start()
    {
        volume = gameObject.GetComponent<Volume>();
        volume.profile.TryGet(out distorsionLayer);
        baseValue = distorsionLayer.intensity.value;
    }

    // Update is called once per frame
    void Update()
    {
        var currentS = PlayerManager.Instance.CurrentSize;
        var baseS = PlayerManager.Instance.BaseSize;
        distorsionLayer.intensity.value = baseValue - currentS * multiplyFx;
    }
}
