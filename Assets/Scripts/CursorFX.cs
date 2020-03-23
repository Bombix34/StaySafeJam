using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFX : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;
    }
}
