using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class subtitulostransformacion : MonoBehaviour
{
    public float _ct;
    public float[] _mt;
    public Text _txt;
    public Image _img;
    public string[] _subs;
    // Start is called before the first frame update
    void Start()
    {
        _img = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _ct += Time.deltaTime;
        if (_ct >= _mt[0])
        {
            _txt.enabled = true;
            _img.enabled = true;
        }
        if (_ct >= _mt[1])
        {
            _txt.text = _subs[0];
        }
        if (_ct >= _mt[2])
        {
            _txt.text = _subs[1];
        }
        if (_ct >= _mt[3])
        {
            _txt.enabled = false;
            _img.enabled = false;
        }
    }
}
