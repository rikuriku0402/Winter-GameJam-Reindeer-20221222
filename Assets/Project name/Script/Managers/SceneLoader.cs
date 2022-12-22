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
    /// シーンを変える関数
    /// </summary>
    /// <param name="scene">シーン名</param>
    public async void FadeIn(string scene)
    {
        await _fadeImage.DOFade(endValue: 1f, duration: 1f).AsyncWaitForCompletion();
        await SceneManager.LoadSceneAsync(scene);
    }

    /// <summary>
    /// シーンを変えた時に最初に呼び出すもの
    /// </summary>
    public void FadeOut()
    {
        _fadeImage.DOFade(endValue: 0f, duration: 1f);
    }
}
