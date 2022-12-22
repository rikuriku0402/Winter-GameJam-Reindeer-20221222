using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleButton : MonoBehaviour
{
   [SerializeField] const string SCENE_NAME = "FukuwaraiStartScene";

    [SerializeField]
    [Header("タイトル画面ボタン")]
    private Button _titlebutton;
    void Start()
    {
        _titlebutton.onClick.AddListener(() => SceneLoader.Instance.FadeIn(SCENE_NAME));

    }

    void Update()
    {
        if (TimeManager.Instance.IsTimeOver)
        {
            _titlebutton.gameObject.SetActive(true);
        }
    }
}
