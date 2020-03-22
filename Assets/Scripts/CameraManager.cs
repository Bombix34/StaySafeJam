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
        initCamSize = m_camera.orthographicSize;
        sizeToSet = m_camera.orthographicSize;
    }

    private void Update()
    {
        if(m_camera.orthographicSize<sizeToSet)
        {
            m_camera.orthographicSize += Time.deltaTime * speedCam ;
        }
        else if (m_camera.orthographicSize > sizeToSet)
        {
            m_camera.orthographicSize -= Time.deltaTime * speedCam;
        }
    }

    public void ChangeSize(float curScaleMagnitude)
    {
        sizeToSet = (curScaleMagnitude * initCamSize) / BaseScaleMagnitude;
    }
}
