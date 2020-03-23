using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    public float multiplyDeform = 0.01f;
    public float fxSpeedBumper = 1;

    Material playerMat;
    float deformValue = 0;
    bool launch;
    float time;
    bool increased;
    float minOffset;

    void Start()
    {
        playerMat = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpriteRenderer>().material;
        minOffset = playerMat.GetFloat("_DeformOffset");
    }

    public void PlayerMatFX()
    {
        deformValue += multiplyDeform;
        playerMat.SetFloat("_DeformIntensity", deformValue);

        time = 0;
        increased = false;
        launch = true;
    }

    private void Update()
    {
        if (launch)
        {
            time = Mathf.Clamp(time, 0, 1);
            playerMat.SetFloat("_DeformOffset", Mathf.Lerp(minOffset, 1, time));

            if (!increased)
            {
                time += Time.deltaTime * fxSpeedBumper;
                increased = time >= 1 ? true : false;
            }

            else
            {
                time -= Time.deltaTime * fxSpeedBumper;
                increased = time <= 0 ? false : true;
                launch = time <= 0 ? false : true;
            }
        }
    }
}
