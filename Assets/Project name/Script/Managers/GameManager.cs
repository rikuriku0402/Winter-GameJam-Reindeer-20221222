using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool IsGame => _isGame;

    bool _isGame;

    [SerializeField]
    [Header("�Q�[���N���A�L�����o�X")]
    GameObject _gameClearCanvas;

    [SerializeField]
    [Header("�Q�[���I�[�o�[�L�����o�X")]
    GameObject _gameOverCanvas;

    [SerializeField]
    [Header("���g���C�{�^��")]
    Button _retryButton;

    [SerializeField]
    [Header("�^�C�g���{�^��")]
    Button _titleButton;

    private void Start()
    {
        _isGame = true;
        _gameClearCanvas.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(false);
        _retryButton.onClick.AddListener(() => SceneLoader.Instance.FadeIn("�V�[����"));
        _titleButton.onClick.AddListener(() => SceneLoader.Instance.FadeIn("�V�[����"));
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
