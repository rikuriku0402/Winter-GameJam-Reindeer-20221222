using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] float _maxSize;
    private void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * _speed);

        if(transform.position.y <= -_maxSize)
        {
            transform.position = new Vector3(0, _maxSize);
        }
    }
}
