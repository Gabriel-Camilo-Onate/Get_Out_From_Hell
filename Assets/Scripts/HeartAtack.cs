using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAtack : MonoBehaviour
{
    public AudioSource _aS;
    private Player _p;
    public float _d;
    // Start is called before the first frame update
    void Start()
    {
        _p = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _d = _p.transform.position.z - transform.position.z;
            _aS.Play();
    }
}
