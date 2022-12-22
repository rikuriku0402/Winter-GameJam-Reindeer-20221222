using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool IsGame => _isGame;

    bool _isGame;

    [SerializeField]
    [Header("リトライするシーン名")]
    string _retrySceneName;

    [SerializeField]
    [Header("タイトルのシーン名")]
    string _titleSceneName;

    [SerializeField]
    [Header("ゲームクリアキャンバス")]
    GameObject _gameEndCanvas;

    [SerializeField]
    [Header("リトライボタン")]
    Button _retryButton;

    [SerializeField]
    [Header("タイトルボタン")]
    Button _titleButton;

    private void Start()
    {
        _isGame = true;
        _gameEndCanvas.gameObject.SetActive(false);
        _retryButton.onClick.AddListener(() => SceneLoader.Instance.FadeIn(_retrySceneName));
        _titleButton.onClick.AddListener(() => SceneLoader.Instance.FadeIn(_titleSceneName));
    }

    public void GameEnd()
    {
        _gameEndCanvas.gameObject.SetActive(true);
        _retryButton.gameObject.SetActive(true);
        _titleButton.gameObject.SetActive(true);
        _isGame = false;
    }
}
