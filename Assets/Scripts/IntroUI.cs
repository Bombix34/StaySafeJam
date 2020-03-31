using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IntroUI : Singleton<IntroUI>
{
    public float appearSpeed = 4f;
    public float dissapearSpeed = 2f;
    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Text creditText;

    private void Start()
    {
        titleText.color = new Color(0f,0f,0f,0f);
        creditText.color = new Color(0f, 0f, 0f, 0f);
    }

    public void LaunchIntroUI()
    {
        Sequence titleSequence = DOTween.Sequence();
        titleSequence.Append(titleText.DOColor(new Color(1f, 1f, 1f, 1f), appearSpeed));
        titleSequence.Append(titleText.DOColor(new Color(1f, 1f, 1f, 0f), dissapearSpeed));
        Sequence creditSequence = DOTween.Sequence();
        creditSequence.Append(creditText.DOColor(new Color(1f, 1f, 1f, 1f), appearSpeed));
        creditSequence.Append(creditText.DOColor(new Color(1f, 1f, 1f, 0f), dissapearSpeed));
    }

}
