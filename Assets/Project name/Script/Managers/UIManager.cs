using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    public Text TimeText => _timeText;
    
    public Text ScoreText => _scoreText;

    [SerializeField]
    [Header("スコアテキスト")]
    Text _scoreText;

    [SerializeField]
    [Header("タイムテキスト")]
    Text _timeText;

    void Start()
    {
        _scoreText.text = 0.ToString("d2");
        _timeText.text = 0.ToString("f2");
    }
}
