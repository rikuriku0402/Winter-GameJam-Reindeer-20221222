using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool IsGame => _isGame;

    bool _isGame;

    [SerializeField]
    [Header("ゲームクリアキャンバス")]
    GameObject _gameClearCanvas;

    [SerializeField]
    [Header("ゲームオーバーキャンバス")]
    GameObject _gameOverCanvas;

    [SerializeField]
    [Header("リトライボタン")]
    Button _retryButton;

    [SerializeField]
    [Header("タイトルボタン")]
    Button _titleButton;

    private void Start()
    {
        _isGame = true;
        _gameClearCanvas.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(false);
        _retryButton.onClick.AddListener(() => SceneLoader.Instance.FadeIn("シーン名"));
        _titleButton.onClick.AddListener(() => SceneLoader.Instance.FadeIn("シーン名"));
    }

    public void GameClear()
    {
        _gameClearCanvas.gameObject.SetActive(true);
        _retryButton.gameObject.SetActive(true);
        _titleButton.gameObject.SetActive(true);
        _isGame = false;
    }

    public void GameOver()
    {
        _gameOverCanvas.gameObject.SetActive(true);
        _retryButton.gameObject.SetActive(true);
        _titleButton.gameObject.SetActive(true);
        _isGame = false;
    }
}
