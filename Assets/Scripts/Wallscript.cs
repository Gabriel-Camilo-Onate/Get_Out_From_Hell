using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallscript : MonoBehaviour
{
    public Transform[] _points;
    public int _nextWaypoint;
    public bool _goingBack;
    public float _minRange;
    public float _speed;
    void Update()
    {
            if (Vector3.Distance(transform.position, _points[_nextWaypoint].position) <= _minRange)
            {
                if (_nextWaypoint == _points.Length - 1)
                    _goingBack = true;
                else if (_nextWaypoint == 0)
                    _goingBack = false;

                if (!_goingBack)
                    _nextWaypoint++;
                else
                    _nextWaypoint--;
            }
        transform.position += (_points[_nextWaypoint].position - transform.position).normalized * _speed * Time.deltaTime;
    }
}
