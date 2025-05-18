using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMover : MonoBehaviour
{
    public float _speed;
    public float _timeToArrive;
    public float _timeToArrive2;
    public Vector2 _d;
    public Vector2 _position;
    public float _cTime2;
    private RectTransform rectTransform;
    private Vector2 _targetP=new Vector2(0,450);
    private bool _doed;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
         _position = rectTransform.anchoredPosition;
        _d = _targetP - _position;
        _speed = _d.y / _timeToArrive2;
    }

    public void Movardo()
    {
        if (!_doed)
        {

        _d = _targetP - _position;
        _cTime2 += Time.deltaTime;
        if (_cTime2>=_timeToArrive && _position.y != _targetP.y)
        {
        _position.y += _speed * Time.deltaTime;
        }
        if (_position.y > _targetP.y)
            {
            _position.y = _targetP.y;
                _doed = true;
            }

        }

        rectTransform.anchoredPosition = _position;
    }
}
