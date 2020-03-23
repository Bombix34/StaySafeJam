using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellManager : MonoBehaviour
{
    public float initSizeSpeed = 1f;
    public List<Sprite> spritesList;
    public Color[] colorsList;
    public Material cellmat;
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
            float speed = PlayerManager.Instance.GetAdaptedValue(0.075f);
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
                CellRandom(sprite);
                break;
            case CellType.neutralGrow:
                sprite.sprite = spritesList[1];
                CellRandom(sprite);
                break;
            case CellType.shrink:
                sprite.sprite = spritesList[2];
                CellRandom(sprite);
                break;
            case CellType.sound:
                sprite.sprite = spritesList[3];
                CellRandom(sprite);
                break;
            case CellType.visual:
                sprite.sprite = spritesList[4];
                CellRandom(sprite);
                break;
        }
    }

    void CellRandom(SpriteRenderer spriteCell)
    {
        spriteCell.material = cellmat;
        spriteCell.material.SetColor("_Color", colorsList[Random.Range(0, colorsList.Length)]);
        spriteCell.material.SetFloat("_OpacityTextureFX02", Random.Range(0f, 1f));
        spriteCell.material.SetFloat("_Tiling", Random.Range(0.1f, 0.3f));
        spriteCell.material.SetInt("_Fuck", Random.Range(0, 2));
        spriteCell.material.SetFloat("_FuckedUpColor", Random.Range(0f, 1f));
        spriteCell.material.SetInt("_AddGradient", Random.Range(0, 2));
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
