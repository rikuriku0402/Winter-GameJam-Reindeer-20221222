using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    public Text TimeText => _timeText;
    
    public Text ScoreText => _scoreText;

    [SerializeField]
    [Header("�X�R�A�e�L�X�g")]
    Text _scoreText;

    [SerializeField]
    [Header("�^�C���e�L�X�g")]
    Text _timeText;

    void Start()
    {
        _scoreText.text = 0.ToString("d2");
        _timeText.text = 0.ToString("f2");
    }
}
