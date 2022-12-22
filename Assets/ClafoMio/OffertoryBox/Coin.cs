using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _minPos;
    private void Update()
    {
        transform.position -= new Vector3(0, _speed);

        if (transform.position.y < _minPos)
        {
            CoinGenerator._nowCoin--;
            Destroy(gameObject);
        }

        
    }
}
