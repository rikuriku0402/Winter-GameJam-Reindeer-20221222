using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool IsGame => _isGame;

    bool _isGame;

    [SerializeField]
    [Header("���g���C����V�[����")]
    string _retrySceneName;

    [SerializeField]
    [Header("�^�C�g���̃V�[����")]
    string _titleSceneName;

    [SerializeField]
    [Header("�Q�[���N���A�L�����o�X")]
    GameObject _gameEndCanvas;

    [SerializeField]
    [Header("���g���C�{�^��")]
    Button _retryButton;

    [SerializeField]
    [Header("�^�C�g���{�^��")]
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
