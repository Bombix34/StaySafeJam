using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellManager : MonoBehaviour
{
    public float initSizeSpeed = 1f;
    private CellType cellType;

    [SerializeField]
    private SpriteRenderer sprite;

    private void Update()
    {
        if(cellType==CellType.neutralGrow)
        {
            this.transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime, transform.localScale.x + (Time.deltaTime*0.2f), transform.localScale.x + (Time.deltaTime * 0.2f));
        }
    }

    public void InitScale(float newScale, float bumpSize)
    {
        InitType();
        Sequence scaleSequence = DOTween.Sequence();
        scaleSequence.Append(this.transform.DOScale(newScale*bumpSize, Time.deltaTime * PlayerManager.Instance.GetAdaptedValue(initSizeSpeed)));
        scaleSequence.Append(this.transform.DOScale(newScale, Time.deltaTime * PlayerManager.Instance.GetAdaptedValue(initSizeSpeed*0.8f)));
    }

    private void InitType()
    {
        cellType = (CellType)Random.Range(0, (int)CellType.size);
        switch (cellType)
        {
            case CellType.neutral:
                sprite.color = Color.white;
                break;
            case CellType.neutralGrow:
                sprite.color = Color.grey;
                break;
            case CellType.shrink:
                sprite.color = new Color(0.6f, 0.1f, 0f);
                break;
            case CellType.sound:
                sprite.color = new Color(0.8f, 0f, 0.4f);
                break;
            case CellType.visual:
                sprite.color = new Color(0f, 0.2f, 0.8f);
                break;
        }
    }

    public void OnEat()
    {
        switch(cellType)
        {
            case CellType.neutral:
                break;
            case CellType.neutralGrow:
                break;
            case CellType.shrink:
                break;
            case CellType.sound:
                break;
            case CellType.visual:
                break;
        }
    }

    public enum CellType
    {
        visual,
        sound,
        neutralGrow,
        neutral,
        shrink,
        size
    }
}
