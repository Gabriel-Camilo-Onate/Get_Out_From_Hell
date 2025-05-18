using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    private Player _player;
    private Image _image;
    public float _cTime;
    public float _maxTime;
    private bool _ended;
    private Text _text;
    public Button _bt;
    public Text _brText;
    public float _waitTime;
    private float _cwaitTime;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _image=GetComponent<Image>();
        _text = GetComponentInChildren<Text>();
        _bt.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (_player._win)
        {
            Wait();
        }
    }
    void Wait()
    {
        _cwaitTime += Time.deltaTime;
            if(_cwaitTime >= _waitTime)
        {
            ChangeColor();

        }
    }
    void ChangeColor()
    {
        if (_ended)
            return;
        _cTime += Time.deltaTime;

        _image.color = new Color(0,0,0,_image.color.a+(1/ _maxTime*Time.deltaTime));
        _text.color= new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a + (1 / _maxTime * Time.deltaTime));
        _bt.image.color= new Color(192,192,192, _bt.colors.normalColor.a + (1 / _maxTime * Time.deltaTime));
        _brText.color = new Color(_brText.color.r, _brText.color.g, _brText.color.b, _brText.color.a + (1 / _maxTime * Time.deltaTime));
        if (_cTime >= _maxTime)
        {
            _ended=true;
            _bt.enabled = true;
            _cTime = 0;
        }
    }
}
