using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObstacle : MonoBehaviour
{
    [SerializeField]
    [Header("�X�R�A")]
    int _score;
    private void OnMouseDown()
    {
        MoneyMeter.Instance.PlusMoney(_score);
        Destroy(gameObject);
        print("�N���b�N");
    }
}
