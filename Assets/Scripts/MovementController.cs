﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool needClickToMove = true;

    public int m_speed=1;
    public float maxSpeed = 10f;
    private Rigidbody2D m_body;

    private void Start()
    {
        m_body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        UpdateMovement();
        ClampVelocity();
    }

    private void UpdateMovement()
    {
        if (needClickToMove)
        {
            UpdateMouseMovementOnClick();
        }
        else
        {
            UpdateMouseMovementWithoutClick();
        }
    }

    private void UpdateMouseMovementOnClick()
    {
        //décélération
        Vector2 curForce = (-1f * m_body.velocity * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0f);
            Vector2 dirVector = (mousePosition - this.transform.position).normalized;
            //accélération
            curForce += (dirVector * m_speed) * Time.deltaTime;
        }
        m_body.velocity += curForce;
    }

    private void UpdateMouseMovementWithoutClick()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0f);
        Vector2 dirVector = (mousePosition - this.transform.position).normalized;
        //accélération
        Vector2 curForce = (dirVector * m_speed) * Time.deltaTime;
        m_body.velocity += curForce;
    }

    private void ClampVelocity()
    {
        if(m_body.velocity.magnitude >= maxSpeed)
        {
            m_body.velocity = Vector2.ClampMagnitude(m_body.velocity, maxSpeed);
        }
    }
}
