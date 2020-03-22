using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class EatManager : MonoBehaviour
{
    public float speedEat=1;
    public float speedScale = 1;

    public UnityEvent onPlayerEatCellEvent;

    private void Start()
    {
        if (this.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraManager>().BaseScaleMagnitude = this.transform.localScale.magnitude;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cell")|| collision.gameObject.CompareTag("Player"))
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
        Vector3 finalScale = eater.transform.localScale + (eaten.transform.localScale*0.15f);
        if ((finalScale.magnitude >= 150)&& (eater.CompareTag("Player")))
        {
            CameraManager.Instance.ForceDecreaseOrthographicSize(6f, PlayerManager.Instance.GetAdaptedValue(CameraManager.Instance.speedCam));
            finalScale = Vector3.ClampMagnitude(finalScale, 0.8f);
            SpawnerManager.Instance.ClearCells();
        }
        other.DOMove(eater.transform.position, speedEat);
        eaten.transform.DOScale(Vector3.zero, speedScale);
        eaten.GetComponent<MovementController>()?.ResetVelocity();
        Sequence animSequence = DOTween.Sequence();
        animSequence.Append(eater.transform.DOScale(finalScale, speedScale ).OnComplete(() => { Destroy(eaten); }));
        SpawnerManager.Instance.CurrentCells.Remove(eaten);
        if(eater.CompareTag("Player"))
        {
            onPlayerEatCellEvent.Invoke();
            eater.GetComponent<PlayerManager>().CurrentSize = finalScale.magnitude;
            Camera.main.GetComponent<CameraManager>().ChangeSize(finalScale.magnitude);
            eater.GetComponent<MovementController>().ChangeSpeed(finalScale.magnitude);
        }
        else if(eaten.CompareTag("Player"))
        {
            eaten.GetComponent<CameraFollow>().enabled = false;
            eater.AddComponent<CameraFollow>();
        }
    }
}
