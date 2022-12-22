using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public int Score => _score;
    
    int _score;

    /// <summary>
    /// スコアを加算する時これを呼ぶ
    /// テキストも更新される
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        _score += score;
        UpDateScoreText();
    }

    /// <summary>
    /// スコアを減算する時これを呼ぶ
    /// テキストも更新される
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
