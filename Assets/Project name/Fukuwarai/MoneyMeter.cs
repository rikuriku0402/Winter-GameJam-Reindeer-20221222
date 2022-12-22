using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMeter : SingletonMonoBehaviour<MoneyMeter>
{
    [SerializeField]
    float _maxMoney = 100;

    float _currentMoney; 

    [SerializeField]
    Slider _moneySlider;

    [SerializeField]
    Text _moneyGageText;

    void Start()
    {
        //Ç®ã‡ÉQÅ[ÉW
        _moneySlider.maxValue = _maxMoney;
        _currentMoney = _moneySlider.minValue;
        _moneySlider.value = _currentMoney;
        _moneyGageText.text = _moneySlider.value.ToString();
    }

    void Update()
    {
        
    }

    public void PlusMoney(int score)
    {
        ScoreManager.Instance.AddScore(score);
        _currentMoney += score;
        _moneySlider.value = _currentMoney;

    }
}
