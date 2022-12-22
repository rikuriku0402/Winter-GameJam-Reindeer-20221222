using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "FaceData",
  menuName = "ScriptableObject/FaceData")]
public class FacePartsImage : ScriptableObject
{
    /// <summary>�p�[�c�f�[�^</summary>
    public List<FaceData> FaceDatas => _faceDatas;

    [SerializeField]
    [Header("�p�[�c�f�[�^")]
    List<FaceData> _faceDatas = new List<FaceData>();
}
[System.Serializable]
public class FaceData
{
    /// <summary>��̐l�̖��O</summary>
    public string Name => _name;

    /// <summary>�p�[�c�ꗗ</summary>
    public Sprite[] FaceSprite => _faceSprite;

    [SerializeField]
    [Header("�N�̊�H")]
    string _name;

    [SerializeField]
    [Header("�p�[�c�C���[�W")]
    Sprite[] _faceSprite;
}