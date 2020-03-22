using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera m_camera;

    private void Start()
    {
        m_camera = Camera.main;   
    }

    private void Update()
    {
        if(this.GetComponent<MovementController>() != null)
        {
            Vector2 destPos = this.GetComponent<MovementController>().PositionWithVelocity;
            m_camera.transform.position = Vector2.Lerp(m_camera.transform.position, destPos, Time.deltaTime);
        }
        else
        {
            m_camera.transform.position = Vector2.Lerp(m_camera.transform.position, this.transform.position, Time.deltaTime);
        }
        m_camera.transform.position = new Vector3(m_camera.transform.position.x, m_camera.transform.position.y, -10f);
    }
}
