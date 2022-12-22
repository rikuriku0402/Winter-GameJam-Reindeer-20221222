using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PauseManager : SingletonMonoBehaviour<PauseManager>
{
    int _pauseCount = 0;
    public void PauseStart()
    {
        print("ポーズ中");
        SoundManager.Instance.Pause();
        Time.timeScale = 0f;
    }

    public void PauseEnd()
    {
        print("ポーズ終了");
        SoundManager.Instance.Restart();
        Time.timeScale = 1f;
    }

    private void Start()
    {
        this.UpdateAsObservable().Subscribe(x => PauseCheck());
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseCount++;
            switch (_pauseCount)
            {
                case 1:
                    PauseStart();
                    break;
                case 2:
                    PauseEnd();
                    break;
            }
            if (_pauseCount == 2)
            {
                _pauseCount = 0;
            }
        }
    }
}
