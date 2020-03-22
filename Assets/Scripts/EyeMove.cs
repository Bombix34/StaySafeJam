using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMove : MonoBehaviour
{
    private MovementController movement;
    public int speed = 1;

    private void Start()
    {
        movement = GetComponentInParent<MovementController>();
    }

    private void Update()
    {
        Vector3 vectorToTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vectorToTarget = new Vector3(vectorToTarget.x, vectorToTarget.y, 0f).normalized;
        if (movement.PositionWithVelocity.magnitude!=0)
        {
            vectorToTarget = (movement.PositionWithVelocity - (Vector2)this.transform.position).normalized;
        }
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
}
