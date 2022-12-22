using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ObstacleGenerater : MonoBehaviour
{
    int _frame = 0;

    float _minX, _maxX, _minY, _maxY;// �����͈�

    [SerializeField]
    [Header("�����I�u�W�F�N�g")]
    GameObject[] _obstacles;

    [SerializeField]
    [Header("�����ʒu")]
    Transform _pos;

    [SerializeField]
    [Header("�����ʒu")]
    Transform _pos2;

    [SerializeField]
    [Header("��������Ԋu")]
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
    /// ��Q���𐶐�����֐�
    /// </summary>
    private void ObstacleGeneration()
    {
        if (GameManager.Instance.IsGame)
        {
            ++_frame;

            if (_frame > _generateFrame)
            {
                _frame = 0;

                // �����_���Ŏ�ނƈʒu�����߂�
                int index = Random.Range(0, _obstacles.Length);
                float posX = Random.Range(_minX, _maxX);
                float posY = Random.Range(_minY, _maxY);

                GameObject obj = Instantiate(_obstacles[index], new Vector3(posX, posY, 0f), Quaternion.identity);
            }
        }
    }
}
