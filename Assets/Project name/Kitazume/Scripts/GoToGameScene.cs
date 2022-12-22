using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGameScene : MonoBehaviour
{
    [SerializeField]
    string SceneName;

    public void SceneChange()
    {
        SceneLoader.Instance.FadeIn(SceneName);
    }





}
