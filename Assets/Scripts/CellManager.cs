using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellManager : MonoBehaviour
{
    public float initSizeSpeed = 1f;
    public List<Sprite> spritesList;
    private CellType cellType;

    [SerializeField]
    private SpriteRenderer sprite;

    private Rigidbody2D m_body;

    private void Start()
    {
        InitType();
    }

    private void Update()
    {
        if (cellType == CellType.neutralGrow)
        {
            float speed = PlayerManager.Instance.GetAdaptedValue(0.2f);
            this.transform.localScale = new Vector3(transform.localScale.x + (Time.deltaTime * speed), transform.localScale.x + (Time.deltaTime * speed), transform.localScale.x + (Time.deltaTime * speed));
        }
    }

    public void InitScale(float newScale, float bumpSize)
    {
        Sequence scaleSequence = DOTween.Sequence();
        scaleSequence.Append(this.transform.DOScale(newScale * bumpSize, Time.deltaTime * PlayerManager.Instance.GetAdaptedValue(initSizeSpeed)));
        scaleSequence.Append(this.transform.DOScale(newScale, Time.deltaTime * PlayerManager.Instance.GetAdaptedValue(initSizeSpeed * 0.8f)));
    }

    private void InitType()
    {
        cellType = (CellType)Random.Range(0, (int)CellType.size);
        switch (cellType)
        {
            case CellType.neutral:
                sprite.sprite = spritesList[0];
                sprite.color = Color.white;
                break;
            case CellType.neutralGrow:
                sprite.sprite = spritesList[1];
                sprite.color = Color.grey;
                break;
            case CellType.shrink:
                sprite.sprite = spritesList[2];
                sprite.color = new Color(0.6f, 0.1f, 0f);
                break;
            case CellType.sound:
                sprite.sprite = spritesList[3];
                sprite.color = new Color(0.8f, 0f, 0.4f);
                break;
            case CellType.visual:
                sprite.sprite = spritesList[4];
                sprite.color = new Color(0f, 0.2f, 0.8f);
                break;
        }
    }

    public void OnEat()
    {
        switch (cellType)
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
