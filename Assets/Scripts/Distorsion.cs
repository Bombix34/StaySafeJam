using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Distorsion : MonoBehaviour
{
    public float multiplyFx = 0.05f;
    public float reduceScreen = 0.001f;
    public GameObject globalVolume;

    Volume volume;
    LensDistortion distorsionLayer = null;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out distorsionLayer);
    }

    public void Distortion()
    {
        distorsionLayer.intensity.value -= multiplyFx;
        distorsionLayer.scale.value -= reduceScreen;
    }

    private void Update()
    {
        Vector2 playerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        playerScreenPos.x = playerScreenPos.x / Screen.width;
        playerScreenPos.y = playerScreenPos.y / Screen.height;
        distorsionLayer.center.value = playerScreenPos;
    }
}
