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

}
