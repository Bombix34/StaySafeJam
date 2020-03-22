using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellManager : MonoBehaviour
{
    public float initSizeSpeed = 1f;

    public void InitScale(float newScale, float bumpSize)
    {
        Sequence scaleSequence = DOTween.Sequence();
        scaleSequence.Append(this.transform.DOScale(newScale*bumpSize, Time.deltaTime * PlayerManager.Instance.GetAdaptedValue(initSizeSpeed)));
        scaleSequence.Append(this.transform.DOScale(newScale, Time.deltaTime * PlayerManager.Instance.GetAdaptedValue(initSizeSpeed*0.8f)));

    }
}
