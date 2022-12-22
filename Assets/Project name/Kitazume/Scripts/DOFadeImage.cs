using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DOFadeImage : MonoBehaviour
{
    [SerializeField]
    [Header("最後にオープンするイメージ")]
    private Image _openCurtain;

    [SerializeField]
    [Header("福笑いのタイムマネージャー")]
    private TimeManager _timeManager;
    
    [SerializeField]
    private float _openCurtainSpeed = 0.1f;
    void Start()
    {
        
    }
    public void OpenCurtain()
    {
        //Shutterの位置を_openCurtainSpeedの値の速度で指定した座標に移動する
        _openCurtain.rectTransform.DOAnchorPosY(900, _openCurtainSpeed)
                                  .SetLink(gameObject)
                                  .SetEase(Ease.Linear);
    }

    void Update()
    {
        if (_timeManager.IsTimeOver)
        {
            OpenCurtain();
        }
    }
}
