using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float maxSize;
    private void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        if(transform.position.y <= -maxSize)
        {
            transform.position = new Vector3(0, maxSize);
        }
    }
}
