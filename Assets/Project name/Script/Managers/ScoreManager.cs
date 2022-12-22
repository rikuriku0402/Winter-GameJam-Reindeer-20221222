using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public int Score => _score;
    
    int _score;

    /// <summary>
    /// �X�R�A�����Z���鎞������Ă�
    /// �e�L�X�g���X�V�����
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        _score += score;
        UpDateScoreText();
    }

    /// <summary>
    /// �X�R�A�����Z���鎞������Ă�
    /// �e�L�X�g���X�V�����
    /// </summary>
    /// <param name="score"></param>
    public void DecreaseScore(int score)
    {
        _score -= score;
        UpDateScoreText();
    }

    void UpDateScoreText()
    {
        UIManager.Instance.ScoreText.text = _score.ToString();
    }
}
