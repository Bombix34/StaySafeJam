using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    public float speedCam=1;
    private Camera m_camera;
    private float initCamSize;
    public float BaseScaleMagnitude { get; set; }

    private float sizeToSet = 0f;

    private void Start()
    {
        m_camera = this.GetComponent<Camera>();
        initCamSize = 5f;
        sizeToSet = 5f;
        ForceDecreaseOrthographicSize(5f, 300f);
    }

    private void Update()
    {
    }

    public void ChangeSize(float curScaleMagnitude)
    {
        sizeToSet = PlayerManager.instance.GetAdaptedValue(initCamSize);
        if (m_camera.orthographicSize < sizeToSet)
        {
            ForceIncreaseOrthographicSize(sizeToSet, PlayerManager.instance.GetAdaptedValue(speedCam));
        }
        else if (m_camera.orthographicSize > sizeToSet)
        {
            ForceDecreaseOrthographicSize(sizeToSet, PlayerManager.instance.GetAdaptedValue(speedCam));
        }
    }

    public void ForceDecreaseOrthographicSize(float endVal, float speed)
    {
        StartCoroutine(ForceSize(endVal, speed,true));
    }

    public void ForceIncreaseOrthographicSize(float endVal, float speed)
    {
        StartCoroutine(ForceSize(endVal, speed, false));
    }

    private IEnumerator ForceSize(float endVal, float speed, bool isDecrease)
    {
        if(isDecrease)
        {
            while(m_camera.orthographicSize>endVal)
            {
                m_camera.orthographicSize -= Time.deltaTime * speed;
                yield return null;
            }
        }
        else
        {
            while (m_camera.orthographicSize < endVal)
            {
                m_camera.orthographicSize += Time.deltaTime * speed;
                yield return null;
            }
        }
        m_camera.orthographicSize = endVal;
    }

}
