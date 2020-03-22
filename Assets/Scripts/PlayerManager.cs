using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public float BaseSize { get; set; }
    public float CurrentSize { get; set; }

    private void Start()
    {
        BaseSize = this.transform.localScale.magnitude;
        CurrentSize = BaseSize;
    }
}
