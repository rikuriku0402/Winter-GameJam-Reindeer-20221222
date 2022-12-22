using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitCon : MonoBehaviour
{
    [SerializeField]
    private float _speed;//左右移動速度

    [SerializeField]
    private float _maxRight = 8; //右の最大　画面外行かないように

    [SerializeField]
    private float _maxLeft = -8;
    /*左の最大　画面外行かないように 原点(プレイヤーの初期位置)が0の時
     _maxLeft　は[-N]にする */

    private float Xpos;
    private void Update()
    {
        KaiteController();
        
    }

    void KaiteController()
    {
        if (Input.GetKey(KeyCode.A))//左に移動
        {
            Vector3 nowPos = this.gameObject.transform.position;
            if(nowPos.x >= _maxLeft)
            {
                transform.position -= transform.right * _speed * Time.deltaTime;
            }
            
        }
        if (Input.GetKey(KeyCode.D))//右に移動
        {
            Vector3 nowPos = this.gameObject.transform.position;
            if (nowPos.x <= _maxRight)
            {
                transform.position += transform.right * _speed * Time.deltaTime;
            }
                
        }
    }
}
