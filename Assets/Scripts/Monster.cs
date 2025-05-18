using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Player _player;
    private float _distance;
    public float _distanceToRun;
    public float _distanceToWalk;
    public Animator[] _animator;
    public float _orAnimatorSpeed;
    public float _runSpeed;
    public float _walkSpeed;

    public bool _tuto;


    public float _mTime;
    public float _cTime;



    public float _cRTime;
    public float _mRTime;
    public float _aceleration;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
     
        if (!_tuto)
        {
            _orAnimatorSpeed =_animator[0].speed;
        }
        else
        {
            _runSpeed -= 1;
            _orAnimatorSpeed = 0.7f;
        }
        }

    // Update is called once per frame
    void Update()
    {
        if (_tuto)
        {
            _cTime += Time.deltaTime;
            if(_mTime>= _cTime)
            {
                for (int i = 0; i < _animator.Length; i++)
                {

                _animator[i].SetBool("Looking", true);
                }
            }
            else
            {
                for (int i = 0; i < _animator.Length; i++)
                {

                _animator[i].SetBool("Looking", false);
                }
            for (int i = 0; i < _animator.Length; i++)
            {

            _animator[i].speed = 0.7f;
            }

            }
        }
        else
        {
            NormalRun();
        }
        if (_player._win)
        {
            for (int i = 0; i < _animator.Length; i++)
            {
                Destroy(_animator[i].gameObject);
            }
        }
    }

    public void NormalRun()
    {
        _cRTime += Time.deltaTime;
            if (_cRTime >= _mRTime)
        {
            _orAnimatorSpeed += _aceleration;
            _cRTime = 0;
        }
        _distance = _player.transform.position.z - transform.position.z;
        if (_distance < _distanceToWalk )
        {
            for (int i = 0; i < _animator.Length; i++)
            {

            _animator[i].speed = _orAnimatorSpeed - _walkSpeed;
            }
        }
        if (_distance > _distanceToWalk  || _distance < _distanceToRun )
        {
            for (int i = 0; i < _animator.Length; i++)
            {

            _animator[i].speed = _orAnimatorSpeed;
            }
        }

        if (_distance > _distanceToRun )
        {
            for (int i = 0; i < _animator.Length; i++)
            {

            _animator[i].speed = _orAnimatorSpeed + _runSpeed;
            }
        }
    }
}
