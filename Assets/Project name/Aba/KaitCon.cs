using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitCon : MonoBehaviour
{
    [SerializeField]
    private float _speed;//���E�ړ����x

    [SerializeField]
    private float _maxRight = 8; //�E�̍ő�@��ʊO�s���Ȃ��悤��

    [SerializeField]
    private float _maxLeft = -8;
    /*���̍ő�@��ʊO�s���Ȃ��悤�� ���_(�v���C���[�̏����ʒu)��0�̎�
     _maxLeft�@��[-N]�ɂ��� */

    private float Xpos;
    private void Update()
    {
        KaiteController();
        
    }

    void KaiteController()
    {
        if (Input.GetKey(KeyCode.A))//���Ɉړ�
        {
            Vector3 nowPos = this.gameObject.transform.position;
            if(nowPos.x >= _maxLeft)
            {
                transform.position -= transform.right * _speed * Time.deltaTime;
            }
            
        }
        if (Input.GetKey(KeyCode.D))//�E�Ɉړ�
        {
            Vector3 nowPos = this.gameObject.transform.position;
            if (nowPos.x <= _maxRight)
            {
                transform.position += transform.right * _speed * Time.deltaTime;
            }
                
        }
    }
}
