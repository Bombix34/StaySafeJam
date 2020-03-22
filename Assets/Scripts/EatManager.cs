﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EatManager : MonoBehaviour
{
    public float speedEat=1;
    public float speedScale = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cell"))
        {
            if(collision.transform.localScale.magnitude > this.transform.localScale.magnitude)
            {
                AbsorbOtherCell(collision.gameObject, this.gameObject);
            }
            else
            {
                AbsorbOtherCell(this.gameObject, collision.gameObject);
            }
        }
    }

    private void AbsorbOtherCell(GameObject eater, GameObject eaten)
    {
        Rigidbody2D other = eaten.GetComponent<Rigidbody2D>();
        Vector3 finalScale = eater.transform.localScale + eaten.transform.localScale;
        other.DOMove(eater.transform.position, speedEat);
        eaten.transform.DOScale(Vector3.zero, speedScale);
        Sequence animSequence = DOTween.Sequence();
        animSequence.Append(eater.transform.DOScale(finalScale, speedScale ).OnComplete(() => { Destroy(eaten); }));
    }
}