using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBDCRatones : MonoBehaviour
{
    public Animator[] _ac;
    private Player _p;
    public bool _doed;

    // Start is called before the first frame update
    void Start()
    {
        _p = FindObjectOfType<Player>();
        _doed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!_doed)
        {

            if (_p._ct3 > 6)
            {
                for (int i = 0; i < _ac.Length; i++)
                {
                    _ac[i].SetBool("Agachao", false);
                }
            
            _doed = true;
        }

        }
    }
}
