using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    const string SCENE_NAME = "FukuwaraiStartScene";

    [SerializeField]
    [Header("Retryƒ{ƒ^ƒ“")]
    private Button _retrybutton;
    void Start()
    {
        _retrybutton.onClick.AddListener(() => SceneLoader.Instance.FadeIn(SCENE_NAME));

    }

    void Update()
    {
        if (TimeManager.Instance.IsTimeOver)
        {
            _retrybutton.gameObject.SetActive(true);
        }
    }
}
