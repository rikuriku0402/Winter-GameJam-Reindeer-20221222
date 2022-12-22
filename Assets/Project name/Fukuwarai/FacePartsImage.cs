using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "FaceData",
  menuName = "ScriptableObject/FaceData")]
public class FacePartsImage : ScriptableObject
{
    /// <summary>パーツデータ</summary>
    public List<FaceData> FaceDatas => _faceDatas;

    [SerializeField]
    [Header("パーツデータ")]
    List<FaceData> _faceDatas = new List<FaceData>();
}
[System.Serializable]
public class FaceData
{
    /// <summary>顔の人の名前</summary>
    public string Name => _name;

    /// <summary>パーツ一覧</summary>
    public Sprite[] FaceSprite => _faceSprite;

    [SerializeField]
    [Header("誰の顔？")]
    string _name;

    [SerializeField]
    [Header("パーツイメージ")]
    Sprite[] _faceSprite;
}