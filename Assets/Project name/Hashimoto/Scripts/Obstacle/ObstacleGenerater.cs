using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ObstacleGenerater : MonoBehaviour
{
    int _frame = 0;

    float _minX, _maxX, _minY, _maxY;// 生成範囲

    [SerializeField]
    [Header("生成オブジェクト")]
    GameObject[] _obstacles;

    [SerializeField]
    [Header("生成位置")]
    Transform _pos;

    [SerializeField]
    [Header("生成位置")]
    Transform _pos2;

    [SerializeField]
    [Header("生成する間隔")]
    int _generateFrame = 30;

    private void Start()
    {
        _minX = Mathf.Min(_pos.position.x, _pos2.position.x);
        _maxX = Mathf.Max(_pos.position.x, _pos2.position.x);
        _minY = Mathf.Min(_pos.position.y, _pos2.position.y);
        _maxY = Mathf.Max(_pos.position.y, _pos2.position.y);

        this.UpdateAsObservable().Subscribe(x => ObstacleGeneration());
    }

    /// <summary>
    /// 障害物を生成する関数
    /// </summary>
    private void ObstacleGeneration()
    {
        if (GameManager.Instance.IsGame)
        {
            ++_frame;

            if (_frame > _generateFrame)
            {
                _frame = 0;

                // ランダムで種類と位置を決める
                int index = Random.Range(0, _obstacles.Length);
                float posX = Random.Range(_minX, _maxX);
                float posY = Random.Range(_minY, _maxY);

                GameObject obj = Instantiate(_obstacles[index], new Vector3(posX, posY, 0f), Quaternion.identity);
            }
        }
    }
}
