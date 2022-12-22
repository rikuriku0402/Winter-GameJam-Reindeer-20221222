using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsStorage : MonoBehaviour
{
    [SerializeField]
    [Header("�e�p�[�c")]
    List<Image> _parts = new();

    int _num;

    [SerializeField]
    [Header("�V�Ԋ�̍ő吔")]
    int _maxNum;

    [SerializeField]
    [Header("��̃p�[�c�ꗗ")]
    FacePartsImage _facePartsImage;

    void Awake()
    {
        _num = Random.Range(0,_maxNum);
        SetFaceImage(_num);
    }

    /// <summary>���I��</summary>
    public void SetFaceImage(int num)
    {
        Debug.Log(_facePartsImage.FaceDatas[num].Name);

        for(int i = 0; i < _parts.Count; i++)
        {
            _parts[i].sprite = _facePartsImage.FaceDatas[num].FaceSprite[i];
        }
    }
}
