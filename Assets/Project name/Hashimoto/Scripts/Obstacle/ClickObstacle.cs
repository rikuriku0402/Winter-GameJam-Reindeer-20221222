using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObstacle : MonoBehaviour
{
    [SerializeField]
    [Header("スコア")]
    int _score;
    private void OnMouseDown()
    {
        MoneyMeter.Instance.PlusMoney(_score);
        Destroy(gameObject);
        print("クリック");
    }
}
