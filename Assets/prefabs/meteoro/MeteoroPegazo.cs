using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MeteoroPegazo : MonoBehaviour
{
    public Transform target;

    public float _timeToImpact;
    public float _power;
    public ParticleSystem _explosion;
    public float _radius;
    public  Player _p;
    public float _distance;

    private void Start()
    {
        _distance = transform.position.y - target.transform.position.y;
    }
    void Update()
    {
        _p = FindObjectOfType<Player>();
        float step =  _distance/_timeToImpact*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
                {
            Expurochon();
                 }
    }
    public void Expurochon()
    {
        if (_p != null)
        {
            if (!_p._jumping)
            {
            _p._rb.AddExplosionForce(_power, transform.position, _radius);
                _p.Jump();
            }
        }
        Destroy(gameObject);
        if(_explosion!=null)
        Instantiate(_explosion,transform.position,transform.rotation);
    }
}
