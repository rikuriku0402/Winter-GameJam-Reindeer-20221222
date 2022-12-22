using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using Cysharp;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{
    [SerializeField]
    [Header("FadeImage")]
    Image _fadeImage;

    private void Start()
    {
        FadeOut();
    }

    /// <summary>
    /// �V�[����ς���֐�
    /// </summary>
    /// <param name="scene">�V�[����</param>
    public async void FadeIn(string scene)
    {
        await _fadeImage.DOFade(endValue: 1f, duration: 1f).AsyncWaitForCompletion();
        await SceneManager.LoadSceneAsync(scene);
    }

    /// <summary>
    /// �V�[����ς������ɍŏ��ɌĂяo������
    /// </summary>
    public void FadeOut()
    {
        _fadeImage.DOFade(endValue: 0f, duration: 1f);
    }
}
