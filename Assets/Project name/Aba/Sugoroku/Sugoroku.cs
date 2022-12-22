using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Cysharp;
using System;
using UnityEngine.SceneManagement;
public class Sugoroku : MonoBehaviour
{
    //メモ　イベントがあるマス　2,5,8,17,21,23,27,30,32,34,36,40,43,45,46,48,49 計17個
    [SerializeField] GameObject[] _allMass;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _diceButton;
    [SerializeField] Text _diceButtonText;
    [SerializeField] Text _eventDiceButtonText;
    [SerializeField] Text _eventText;
    [SerializeField] GameObject _eventDice;
    [SerializeField] string TitlName;

    private int _playerPos;
    private int _enemyPos;
    private int _dice;

    public async void Update()
    {
        if (_playerPos >= 40)
        {
            _eventText.gameObject.SetActive(true);
            _eventText.text = ("ゴール!!おめでとう!!");
            await WaitTime(3);
            SceneManager.LoadScene(TitlName);
        }
        if (_enemyPos >= 40)
        {
            _eventText.gameObject.SetActive(true);
            _eventText.text = ("敵がゴールした...");
            await WaitTime(3);
            SceneManager.LoadScene(TitlName);
        }
    }
    private void Start()
    {
        _diceButton.SetActive(true);
    }

    IEnumerator PlayerTurn()
    {
        _eventText.gameObject.SetActive(true);
        _eventText.text = (_dice + "進む");
        _playerPos += _dice;
        _player.transform.position = _allMass[_playerPos].transform.position;

        switch (_playerPos)
        {
            case 2:
                PlayerEvent(1);//お餅を食べて元気いっぱい
                _eventText.text = ("お餅を食べて元気いっぱい!!1マス進む");
                break;
            case 5:
                PlayerEvent(2);
                _eventText.text = ("お年玉を貰った!嬉しい!!2マス進む");
                break;
            case 8:
                PlayerEvent(-2);
                _eventText.text = ("転んだ!!2マス戻る");
                break;
            case 17:
                PlayerEvent(-3);
                _eventText.text = ("正月太りでショック!!3マス戻る");
                break;
            case 21:
                EnemyEvent(-2);
                _eventText.text = ("敵に餅を投げた!!敵は2マス戻る");
                yield return new WaitForSeconds(4);
                StartCoroutine(EnemyTurn());
                break;
            case 23:
                PlayerEvent(1);
               _eventText.text = ("ラッキー!!1マス進む");
                break;
            //case 27:

               // break;
            case 30:
                PlayerEvent(3);
                _eventText.text = ("初夢で富士山をみた!!3マス進む");
                break;
            case 32:
                PlayerEvent(-3);
                _eventText.text = ("お御籤で大凶...3マス戻る");
                break;
            case 34:
                PlayerEvent(1);
                _eventText.text = ("夢で茄子を見た!!1マス進む");
                break;
            case 36:
                PlayerEvent(2);
                _eventText.text = ("夢で鷹を見た!!2マス進む");
                break;
            //case 40:

                //break;
            case 43:
                ChangeEvent();
                break;
            case 45:
                PlayerEvent(4);
                _eventText.text = ("おせちを食べた!!4マス進む");
                break;
            case 46:
                PlayerEvent(1);
                _eventText.text = ("あとちょっと!!1マス進む");
                break;
            case 48:
                PlayerEvent(-1);
                _eventText.text = ("直前で躓いた...1マス戻る");
                break;

            default:

                if(_playerPos <= 27&& 27<=_playerPos - _dice)
                {
                    _playerPos = 27;
                    _player.transform.position = _allMass[_playerPos].transform.position;
                    StopEvent(true);
                }else
                    if (_playerPos <= 40 && 40 <= _playerPos - _dice)
                {
                    _playerPos = 40;
                    _player.transform.position = _allMass[_playerPos].transform.position;
                    StopEvent(true);
                }
                else
                {
                    StartCoroutine(EnemyTurn());
                    yield return null;
                    
                }
                break;



        }    
    }
    public async void PlayerEvent(int mas)
    {
        await WaitTime(3);
        _eventText.gameObject.SetActive(true);
        /*if (mas < 0)
        {
            _eventText.text = (mas + "マス戻る");
        } else
        {
            _eventText.text = (mas + "進む");
        }
        */

        _playerPos += mas;
        _player.transform.position = _allMass[_playerPos].transform.position;
        await WaitTime(3);
        _eventText.gameObject.SetActive(false);
        StartCoroutine(EnemyTurn());
    }
    public async void EnemyEvent(int mas)
    {
        await WaitTime(3);
        _diceButton.SetActive(true);
        _diceButtonText.text = ("さいころを振る");

        _eventText.gameObject.SetActive(true);
        /*if(mas < 0)
        {
            _eventText.text = ("敵が"+mas + "マス戻る");
        }
        else
        {
            _eventText.text = ("敵が"+mas + "進む");
        }*/
        _enemyPos += mas;
        _enemy.transform.position = _allMass[_enemyPos].transform.position;
        _eventText.gameObject.SetActive(false);
        
    }
    public async void StopEvent(bool player)
    {
        _eventDiceButtonText.text = ("さいころを振る");
        if(player == true)
        {
            _eventText.gameObject.SetActive(true);
            _eventText.text = ("サイコロを振って1~3なら3マス進む!");
            await WaitTime(3);
            _eventText.text = ("4~6なら3マス戻る...");
            await WaitTime(3);
            _eventDice.SetActive(true);
        }
        else
        {
            
            _dice = UnityEngine.Random.Range(1, 7);
            _eventText.gameObject.SetActive(true);
            _eventText.text = ("敵のサイコロの目は" + _dice);
            await WaitTime(3);
            _eventText.gameObject.SetActive(false);
            if (_dice == 1 && _dice == 2 && _dice == 3)
            {
                EnemyEvent(3);

            }
            else
            {
                EnemyEvent(-3);
            }
            
            
        }
    }
    public async void ChangeEvent()
    {
            int A = _playerPos;
            _playerPos = _enemyPos;
            _enemyPos = A;
            _player.transform.position = _allMass[_playerPos].transform.position;
            _enemy.transform.position = _allMass[_enemyPos].transform.position;
        _eventText.gameObject.SetActive(true);
        _eventText.text = ("敵と位置が入れ替わった");
        await WaitTime(3);
        _eventText.gameObject.SetActive(false);
    }
    async UniTask WaitTime(float second)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(second));
    }
    public async void  StopEventDiceButton()
    {
        _dice = UnityEngine.Random.Range(1, 7);
        _eventDiceButtonText.text = ("サイコロの目は" + _dice);
        await WaitTime(3);
        if(_dice == 1 && _dice == 2 && _dice == 3)
        {
            PlayerEvent(3);
        }
        else
        {
            PlayerEvent(-3);
        }
        _diceButton.SetActive(false);


    }
    public async void DiceButton()
    { 
        _dice = UnityEngine.Random.Range(1, 7);
        _diceButtonText.text = ("目は"+ _dice);
        await WaitTime(3);
        StartCoroutine(PlayerTurn());
        _diceButton.SetActive(false);

       
    }

    IEnumerator EnemyTurn()
    {
        _dice = UnityEngine.Random.Range(1, 7);
        _eventText.gameObject.SetActive(true);
        _eventText.text = ("敵の目は" + _dice);
        yield return new WaitForSeconds(3);
        _eventText.text = ("敵は"+_dice + "マス進む");
        yield return new WaitForSeconds(3);
        //_eventText.gameObject.SetActive(false);

        _enemyPos += _dice;
        _enemy.transform.position = _allMass[_enemyPos].transform.position;

        switch (_enemyPos)
        {
            case 2:
                EnemyEvent(1);//お餅を食べて元気いっぱい
                _eventText.text = ("敵がお餅を食べて元気いっぱい!!1マス進む");
                break;
            case 5:
                EnemyEvent(2);
                _eventText.text = ("敵がお年玉を貰った!嬉しい!!2マス進む");
                break;
            case 8:
                EnemyEvent(-2);
                _eventText.text = ("敵が転んだ!!2マス戻る");
                break;
            case 17:
                EnemyEvent(-3);
                _eventText.text = ("敵が正月太りでショック!!3マス戻る");
                break;
            case 21:
                PlayerEvent(-2);
                _eventText.text = ("敵に餅を投げられた...自分は2マス戻る");
                break;
            case 23:
                EnemyEvent(1);
                _eventText.text = ("敵が元気になった!!1マス進む");
                break;
            //case 27:

            // break;
            case 30:
                EnemyEvent(3);
                _eventText.text = ("敵が初夢で富士山をみた!!3マス進む");
                break;
            case 32:
                EnemyEvent(-3);
                _eventText.text = ("敵がお御籤で大凶...3マス戻る");
                break;
            case 34:
                EnemyEvent(1);
                _eventText.text = ("敵が夢で茄子を見た!!1マス進む");
                break;
            case 36:
                EnemyEvent(2);
                _eventText.text = ("敵が夢で鷹を見た!!2マス進む");
                break;
            //case 40:

            //break;
            case 43:
                ChangeEvent();
                break;
            case 45:
                EnemyEvent(4);
                _eventText.text = ("敵はおせちを食べた!!4マス進む");
                break;
            case 46:
                EnemyEvent(1);
                _eventText.text = ("敵がもう少しでゴール!!1マス進む");
                break;
            case 48:
                EnemyEvent(-1);
                _eventText.text = ("敵が直前で躓いた!!1マス戻る");
                break;

            default:

                if (_enemyPos <= 27 && 27 <= _enemyPos - _dice)
                {
                    _enemyPos = 27;
                    _enemy.transform.position = _allMass[_enemyPos].transform.position;
                    StopEvent(false);
                }
                else
                    if (_enemyPos <= 40 && 40 <= _enemyPos - _dice)
                {
                    _enemyPos = 40;
                    _enemy.transform.position = _allMass[_enemyPos].transform.position;
                    StopEvent(false);
                }
                else
                {
                    _diceButton.SetActive(true);
                    _diceButtonText.text = ("さいころを振る");
                    yield return null;


                }
                break;

                //yield return null;
        }

    }
}
