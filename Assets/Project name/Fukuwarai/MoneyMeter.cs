using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMeter : SingletonMonoBehaviour<MoneyMeter>
{
    [SerializeField]
    float _maxMoney ;

    float _currentMoney; 

    [SerializeField]
    Slider _moneySlider;

    [SerializeField]
    Text _moneyGageText;

    [SerializeField]
    [Header("�I���e�L�X�g")]
    Text _endText;


    void Start()
    {
        //�����Q�[�W
        _moneySlider.maxValue = _maxMoney;
        _currentMoney = _moneySlider.minValue;
        _moneySlider.value = _currentMoney;
        _moneyGageText.text = _moneySlider.value.ToString();
    }

    void Update()
    {
        if (TimeManager.Instance.IsTimeOver)
        {
            _endText.gameObject.SetActive(true);
            if (_moneySlider.value <= 500)
            {
                _endText.text = "�S�R���߂���Ȃ��I���N��500�~��I";
            }
            else if (_moneySlider.value <= 5000)
            {
                _endText.text = "�܂��܂��ˁI���N��100�~��I";
            }
            else if (_moneySlider.value == 10000)
            {
                _endText.text = "�������I�I�I10000�~�������I�I�I";
            }
            GameManager.Instance.GameEnd();
        }
    }

    public void PlusMoney(int score)
    {
        ScoreManager.Instance.AddScore(score);
        _currentMoney += score;
        _moneySlider.value = _currentMoney;
    }
}
