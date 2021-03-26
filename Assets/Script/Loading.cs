using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Loading : MonoBehaviour
{
    public Tweener FadeTween;
    public static Loading self;
    public Image BlackMask;
    private void Awake() 
    {
        self = this;
    }
    public void Start() 
    {   
        FadeTween = BlackMask.DOFade(0, 1f);
        BlackOut();
    }
    public void BlackOut() 
    {
        FadeTween.OnComplete(delegate { BlackMaskSetActive(); });
    }
    public void BlackMaskSetActive() 
    {
        BlackMask.gameObject.SetActive(false);
    }
    
    
    /*Step1 創建sequence
    Sequence moveSequence = DOTween.Sequence();

    //Step2 增加動畫排程
    moveSequence.Append(transform.DOMoveZ(forwardVector.z,1f));

    //Step3 (如果)中間要delay
    moveSequence.PrependInterval(1);

    //Step4 (如果)有個動畫需要在Sequence播放時同時播放
    moveSequence.Insert(0, transform.DOScale(new Vector3(3, 3, 3), mySequence.Duration()));
    上面流程也可以直接寫成
    Sequence moveSequence = DOTween.Sequence();
    moveSequence.Append(transform.DOMoveZ(forwardVector.z,1f)).PrependInterval(1).Insert(0, transform.DOScale(new Vector3(3, 3, 3), mySequence.Duration()));
    */
}
