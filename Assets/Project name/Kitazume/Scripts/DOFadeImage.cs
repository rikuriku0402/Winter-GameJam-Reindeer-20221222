using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DOFadeImage : MonoBehaviour
{
    [SerializeField]
    [Header("�Ō�ɃI�[�v������C���[�W")]
    private Image _openCurtain;

    [SerializeField]
    private float _openCurtainSpeed = 0.1f;

    [SerializeField]
    private float _closeCurtainSpeed = 0.1f;
    void Start()
    {
        CloseCurtain();
    }
    public void OpenCurtain()
    {
        //Shutter�̈ʒu��_openCurtainSpeed�̒l�̑��x�Ŏw�肵�����W�Ɉړ�����
        _openCurtain.rectTransform.DOAnchorPosY(900, _openCurtainSpeed)
                                  .SetLink(gameObject)
                                  .SetEase(Ease.Linear);
    }
    public void CloseCurtain()
    {
        //Shutter�̈ʒu��_openCurtainSpeed�̒l�̑��x�Ŏw�肵�����W�Ɉړ�����
        _openCurtain.rectTransform.DOAnchorPosY(130, _closeCurtainSpeed)
                                  .SetLink(gameObject)
                                  .SetEase(Ease.Linear);
    }

    void Update()
    {
        if (TimeManager.Instance.IsTimeOver)
        {
            OpenCurtain();
        }
    }
}
