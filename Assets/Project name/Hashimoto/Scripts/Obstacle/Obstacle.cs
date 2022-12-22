using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IHitable
{
    [SerializeField]
    [Header("スコア")]
    int _score;

    [SerializeField]
    [Header("障害物タイプ")]
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
        print("当たった");
        switch (_type)
        {
            case ObstacleType.Braggart:
                GameManager.Instance.GameEnd();
                break;
        }
        //GameManager.Instance.GameEnd();
    }
}
