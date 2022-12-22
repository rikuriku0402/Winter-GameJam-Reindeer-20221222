using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsStorage : MonoBehaviour
{
    [SerializeField]
    [Header("各パーツ")]
    List<Image> _parts = new();

    int _num;

    [SerializeField]
    [Header("遊ぶ顔の最大数")]
    int _maxNum;

    [SerializeField]
    [Header("顔のパーツ一覧")]
    FacePartsImage _facePartsImage;

    void Awake()
    {
        _num = Random.Range(0,_maxNum);
        SetFaceImage(_num);
    }

    /// <summary>顔を選択</summary>
    public void SetFaceImage(int num)
    {
        Debug.Log(_facePartsImage.FaceDatas[num].Name);

        for(int i = 0; i < _parts.Count; i++)
        {
            _parts[i].sprite = _facePartsImage.FaceDatas[num].FaceSprite[i];
        }
    }
}
