using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatPanel : MonoBehaviour
{
    private Player _player;
    public float _cTime;
    public float _maxTime;
    private bool _ended;
    public Text _text;
    public Text _text2;
    public Image _image;
    public Image _image2;
    public Button _bt;
    public Text _brText;
    public Button _bt2;
    public Text _brText2;
  
    public float _waitTime;
    private float _cwaitTime;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_player._isDead || _player._win)
        {
            Wait();
        }
    }
    void Wait()
    {
        _cwaitTime += Time.deltaTime;
        if (_cwaitTime >= _waitTime)
        {
            if (_player._isDead)
            {
            ChangeColor();
            }
            if (_player._win)
            {
                ChangeColor2();
            }
        }
    }
    void ChangeColor()
    {
        if (_ended)
            return;
        _cTime += Time.deltaTime;

            _bt.enabled = true;
        _image.color = new Color(0, 0, 0, _image.color.a + (1 / _maxTime * Time.deltaTime));
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a + (1 / _maxTime * Time.deltaTime));
        _bt.image.color = new Color(192, 192, 192, _bt.colors.normalColor.a + (1 / _maxTime * Time.deltaTime));
        _brText.color = new Color(_brText.color.r, _brText.color.g, _brText.color.b, _brText.color.a + (1 / _maxTime * Time.deltaTime));
        if (_cTime >= _maxTime)
        {
            _ended = true;
            _cTime = 0;
        }
    }
    void ChangeColor2()
    {
        if (_ended)
            return;
        _cTime += Time.deltaTime;
            _bt2.enabled = true;

        _image2.color = new Color(0, 0, 0, _image.color.a + (1 / _maxTime * Time.deltaTime));
        _text2.color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a + (1 / _maxTime * Time.deltaTime));
        _bt2.image.color = new Color(192, 192, 192, _bt.colors.normalColor.a + (1 / _maxTime * Time.deltaTime));
        _brText2.color = new Color(_brText.color.r, _brText.color.g, _brText.color.b, _brText.color.a + (1 / _maxTime * Time.deltaTime));
        if (_cTime >= _maxTime)
        {
            _ended = true;
            _cTime = 0;
        }
    }
}
