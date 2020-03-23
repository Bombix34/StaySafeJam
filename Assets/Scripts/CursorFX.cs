using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFX : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 dirVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition)-PlayerManager.Instance.transform.position);
        this.transform.position = PlayerManager.Instance.transform.position + (dirVector);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 10f);
    }
}
