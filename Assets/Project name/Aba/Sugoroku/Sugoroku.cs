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
    //�����@�C�x���g������}�X�@2,5,8,17,21,23,27,30,32,34,36,40,43,45,46,48,49 �v17��
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
            _eventText.text = ("�S�[��!!���߂łƂ�!!");
            await WaitTime(3);
            SceneManager.LoadScene(TitlName);
        }
        if (_enemyPos >= 40)
        {
            _eventText.gameObject.SetActive(true);
            _eventText.text = ("�G���S�[������...");
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
        _eventText.text = (_dice + "�i��");
        _playerPos += _dice;
        _player.transform.position = _allMass[_playerPos].transform.position;

        switch (_playerPos)
        {
            case 2:
                PlayerEvent(1);//���݂�H�ׂČ��C�����ς�
                _eventText.text = ("���݂�H�ׂČ��C�����ς�!!1�}�X�i��");
                break;
            case 5:
                PlayerEvent(2);
                _eventText.text = ("���N�ʂ�����!������!!2�}�X�i��");
                break;
            case 8:
                PlayerEvent(-2);
                _eventText.text = ("�]��!!2�}�X�߂�");
                break;
            case 17:
                PlayerEvent(-3);
                _eventText.text = ("��������ŃV���b�N!!3�}�X�߂�");
                break;
            case 21:
                EnemyEvent(-2);
                _eventText.text = ("�G�ɖ݂𓊂���!!�G��2�}�X�߂�");
                yield return new WaitForSeconds(4);
                StartCoroutine(EnemyTurn());
                break;
            case 23:
                PlayerEvent(1);
               _eventText.text = ("���b�L�[!!1�}�X�i��");
                break;
            //case 27:

               // break;
            case 30:
                PlayerEvent(3);
                _eventText.text = ("�����ŕx�m�R���݂�!!3�}�X�i��");
                break;
            case 32:
                PlayerEvent(-3);
                _eventText.text = ("�����܂ő勥...3�}�X�߂�");
                break;
            case 34:
                PlayerEvent(1);
                _eventText.text = ("���ŉ֎q������!!1�}�X�i��");
                break;
            case 36:
                PlayerEvent(2);
                _eventText.text = ("���ő������!!2�}�X�i��");
                break;
            //case 40:

                //break;
            case 43:
                ChangeEvent();
                break;
            case 45:
                PlayerEvent(4);
                _eventText.text = ("��������H�ׂ�!!4�}�X�i��");
                break;
            case 46:
                PlayerEvent(1);
                _eventText.text = ("���Ƃ������!!1�}�X�i��");
                break;
            case 48:
                PlayerEvent(-1);
                _eventText.text = ("���O���T����...1�}�X�߂�");
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
            _eventText.text = (mas + "�}�X�߂�");
        } else
        {
            _eventText.text = (mas + "�i��");
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
        _diceButtonText.text = ("���������U��");

        _eventText.gameObject.SetActive(true);
        /*if(mas < 0)
        {
            _eventText.text = ("�G��"+mas + "�}�X�߂�");
        }
        else
        {
            _eventText.text = ("�G��"+mas + "�i��");
        }*/
        _enemyPos += mas;
        _enemy.transform.position = _allMass[_enemyPos].transform.position;
        _eventText.gameObject.SetActive(false);
        
    }
    public async void StopEvent(bool player)
    {
        _eventDiceButtonText.text = ("���������U��");
        if(player == true)
        {
            _eventText.gameObject.SetActive(true);
            _eventText.text = ("�T�C�R����U����1~3�Ȃ�3�}�X�i��!");
            await WaitTime(3);
            _eventText.text = ("4~6�Ȃ�3�}�X�߂�...");
            await WaitTime(3);
            _eventDice.SetActive(true);
        }
        else
        {
            
            _dice = UnityEngine.Random.Range(1, 7);
            _eventText.gameObject.SetActive(true);
            _eventText.text = ("�G�̃T�C�R���̖ڂ�" + _dice);
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
        _eventText.text = ("�G�ƈʒu������ւ����");
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
        _eventDiceButtonText.text = ("�T�C�R���̖ڂ�" + _dice);
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
        _diceButtonText.text = ("�ڂ�"+ _dice);
        await WaitTime(3);
        StartCoroutine(PlayerTurn());
        _diceButton.SetActive(false);

       
    }

    IEnumerator EnemyTurn()
    {
        _dice = UnityEngine.Random.Range(1, 7);
        _eventText.gameObject.SetActive(true);
        _eventText.text = ("�G�̖ڂ�" + _dice);
        yield return new WaitForSeconds(3);
        _eventText.text = ("�G��"+_dice + "�}�X�i��");
        yield return new WaitForSeconds(3);
        //_eventText.gameObject.SetActive(false);

        _enemyPos += _dice;
        _enemy.transform.position = _allMass[_enemyPos].transform.position;

        switch (_enemyPos)
        {
            case 2:
                EnemyEvent(1);//���݂�H�ׂČ��C�����ς�
                _eventText.text = ("�G�����݂�H�ׂČ��C�����ς�!!1�}�X�i��");
                break;
            case 5:
                EnemyEvent(2);
                _eventText.text = ("�G�����N�ʂ�����!������!!2�}�X�i��");
                break;
            case 8:
                EnemyEvent(-2);
                _eventText.text = ("�G���]��!!2�}�X�߂�");
                break;
            case 17:
                EnemyEvent(-3);
                _eventText.text = ("�G����������ŃV���b�N!!3�}�X�߂�");
                break;
            case 21:
                PlayerEvent(-2);
                _eventText.text = ("�G�ɖ݂𓊂���ꂽ...������2�}�X�߂�");
                break;
            case 23:
                EnemyEvent(1);
                _eventText.text = ("�G�����C�ɂȂ���!!1�}�X�i��");
                break;
            //case 27:

            // break;
            case 30:
                EnemyEvent(3);
                _eventText.text = ("�G�������ŕx�m�R���݂�!!3�}�X�i��");
                break;
            case 32:
                EnemyEvent(-3);
                _eventText.text = ("�G�������܂ő勥...3�}�X�߂�");
                break;
            case 34:
                EnemyEvent(1);
                _eventText.text = ("�G�����ŉ֎q������!!1�}�X�i��");
                break;
            case 36:
                EnemyEvent(2);
                _eventText.text = ("�G�����ő������!!2�}�X�i��");
                break;
            //case 40:

            //break;
            case 43:
                ChangeEvent();
                break;
            case 45:
                EnemyEvent(4);
                _eventText.text = ("�G�͂�������H�ׂ�!!4�}�X�i��");
                break;
            case 46:
                EnemyEvent(1);
                _eventText.text = ("�G�����������ŃS�[��!!1�}�X�i��");
                break;
            case 48:
                EnemyEvent(-1);
                _eventText.text = ("�G�����O���T����!!1�}�X�߂�");
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
                    _diceButtonText.text = ("���������U��");
                    yield return null;


                }
                break;

                //yield return null;
        }

    }
}
