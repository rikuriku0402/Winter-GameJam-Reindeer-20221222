using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IHitable
{
    [SerializeField]
    [Header("�X�R�A")]
    int _score;

    [SerializeField]
    [Header("��Q���^�C�v")]
    ObstacleType _type;

    enum ObstacleType
    {
        None,
        Braggart
    }

    public void Hit()
    {
        ScoreManager.Instance.AddScore(_score);
        print(_score);
        print("��������");
        switch (_type)
        {
            case ObstacleType.Braggart:
                GameManager.Instance.GameEnd();
                break;
        }
        //GameManager.Instance.GameEnd();
    }
}
