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
    [Header("終わりテキスト")]
    Text _endText;


    void Start()
    {
        //お金ゲージ
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
                _endText.text = "全然だめじゃない！今年は500円よ！";
            }
            else if (_moneySlider.value <= 5000)
            {
                _endText.text = "まぁまぁね！今年は100円よ！";
            }
            else if (_moneySlider.value == 10000)
            {
                _endText.text = "すごい！！！10000円あげるわ！！！";
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
