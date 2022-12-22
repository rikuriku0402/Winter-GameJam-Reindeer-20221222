using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Offertory
{
    public class CoinGenerator : MonoBehaviour
    {
        [SerializeField] GameObject _coin;

        [SerializeField] GameObject _startSpawn;
        [SerializeField] GameObject _endSpawn;

        [SerializeField] int _maxCoin;
        public static int _nowCoin;
        private void Update()
        {
            if(_maxCoin -1 >= _nowCoin)
            {
                float x = Random.Range(_startSpawn.transform.position.x, _endSpawn.transform.position.x);
                float y = Random.Range(_startSpawn.transform.position.y, _endSpawn.transform.position.y);

                Instantiate(_coin, new Vector2(x, y), Quaternion.identity);
                _nowCoin++;
            }
        }
    }
}
