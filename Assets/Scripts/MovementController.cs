using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool needClickToMove = true;

    public float m_speed=1;
    public float maxSpeed = 10f;
    private Rigidbody2D m_body;

    private bool isFirstClick = false;
    private float curSpeed;
    private float curMaxSpeed;

    private void Start()
    {
        m_body = GetComponent<Rigidbody2D>();
        curSpeed = m_speed;
        curMaxSpeed = maxSpeed;
    }

    private void FixedUpdate()
    {
        StartMovement();
        if(!isFirstClick)
        {
            return;
        }
        UpdateMovement();
        ClampVelocity();
    }

    private void StartMovement()
    {
        if(isFirstClick || needClickToMove)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            isFirstClick = true;
            SpawnerManager.Instance.CanSpawn = true;
            IntroUI.Instance.LaunchIntroUI();
            MusicManager.Instance.LaunchMusic();
        }
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
            curForce += (dirVector * curSpeed) * Time.deltaTime;
        }
        m_body.velocity += curForce;
    }

    private void UpdateMouseMovementWithoutClick()
    {
        //décélération
        Vector2 curForce = (-1f * m_body.velocity * Time.deltaTime);
        if(!Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0f);
            Vector2 dirVector = (mousePosition - this.transform.position).normalized;
            //accélération
            curForce = (dirVector * curSpeed) * Time.deltaTime;
        }
        m_body.velocity += curForce;
    }

    private void ClampVelocity()
    {
        if(m_body.velocity.magnitude >= curMaxSpeed)
        {
            m_body.velocity = Vector2.ClampMagnitude(m_body.velocity, curMaxSpeed);
        }
    }

    public void ChangeSpeed(float curScaleMagnitude)
    {
        curSpeed = PlayerManager.Instance.GetAdaptedValue(m_speed);
        curMaxSpeed = PlayerManager.Instance.GetAdaptedValue(maxSpeed);
    }

    public void ResetVelocity()
    {
        m_body.velocity = Vector2.zero;
    }

    public Vector2 PositionWithVelocity
    {
        get=>(Vector2)this.transform.position + (m_body.velocity*1.4f);
    }

    public Vector2 Velocity
    {
        get => (Vector2)m_body.velocity;
    }

    public float CurSpeed
    {
        get => curSpeed;
    }
}
