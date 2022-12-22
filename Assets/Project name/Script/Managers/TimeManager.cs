using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class TimeManager : MonoBehaviour
{
    public bool IsTimeOver => _isTimeOver;
    
    bool _isTimeOver;

    [SerializeField]
    [Header("�J�E���g�_�E��")]
    float _countDown = 10f;

    private void Start()
    {
        this.UpdateAsObservable().Subscribe(x => CountDown());
    }

    void CountDown()
    {
        if (!_isTimeOver)
        {
            _countDown -= Time.deltaTime;

            UIManager.Instance.TimeText.text = _countDown.ToString("f1") + "�b";

            if (_countDown <= 0)
            {
                _isTimeOver = true;
                UIManager.Instance.TimeText.text = "0";
                print("����");
            }
        }
    }
}
