using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Offertory
{
    public class PlayerController : MonoBehaviour
    {
        float horizontalKey;
        [SerializeField] float _speed;
        [SerializeField] float _maxTrans;

        [SerializeField] GameObject _coin;
        private void Update()
        {
            
            horizontalKey = Input.GetAxis("Horizontal"); 
            
            if(horizontalKey > 0 && transform.position.x < _maxTrans)
            {
                transform.position += new Vector3(_speed,0);
            }
            else if(horizontalKey < 0 && transform.position.x > -_maxTrans)
            {
                transform.position += new Vector3(-_speed, 0);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            
            if(col.gameObject.layer == _coin.layer)
            {
                Destroy(col.gameObject);
                CoinGenerator._nowCoin--;
                ScoreManager.Instance.AddScore(1);
            }
        }
    }

}
