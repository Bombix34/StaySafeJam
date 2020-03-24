using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Distorsion : MonoBehaviour
{
    public float multiplyFx = 0.05f;
    public float reduceScreen = 0.001f;
    public float newStepDistorsion = -0.9f;
    public float newStepSpeed = 0.5f;
    public GameObject globalVolume;

    Volume volume;
    LensDistortion distorsionLayer = null;
    GameObject player;
    int nbrEat;
    bool nextStep;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        volume = globalVolume.GetComponent<Volume>();
        volume.profile.TryGet(out distorsionLayer);
    }

    public void Distortion()
    {
        if(distorsionLayer.intensity.value > newStepDistorsion && !nextStep)
        {
            distorsionLayer.intensity.value -= multiplyFx;
            distorsionLayer.scale.value -= reduceScreen;
        }

        else
        {
            nextStep = true;
        }
    }

    private void Update()
    {
        Vector2 playerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        playerScreenPos.x = playerScreenPos.x / Screen.width;
        playerScreenPos.y = playerScreenPos.y / Screen.height;
        distorsionLayer.center.value = playerScreenPos;

        if (nextStep)
        {
            distorsionLayer.intensity.value = Mathf.Lerp(newStepDistorsion, Mathf.Abs(newStepDistorsion), Mathf.PingPong(Time.time * newStepSpeed, 1));
        }
    }
}
