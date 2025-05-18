using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class prendealas : MonoBehaviour
{
    public AudioSource _as;
    public GameObject _wings;
    public GameObject _horns;
    public GameObject _light;
    private float _ct;
    public float _mt;
    public AudioClip _xd;
    private bool _do;
    public Text _txt;
    public Image _img;
    public float _maxTime;
    public int _currentScene;
    private Persistente _per;
    // Start is called before the first frame update
    void Start()
    {
        _do = false;
        _per = FindObjectOfType<Persistente>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_do) { 
        if (!_as.isPlaying)
        {
            _ct += Time.deltaTime;
            if(_ct>_mt/2)
                _light.SetActive(false);

            if (_ct > _mt)
            {
            _wings.SetActive(true);
                    _horns.SetActive(true);
                    _as.clip = _xd;
                _as.Play();
                    _as.volume = 0.5f;
                    _do = true;
                    _ct = 0;
            }
        }
        }
        else
        {
            _ct += Time.deltaTime;
            if (_ct > _mt*5)
            {
            _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, _img.color.a + (1 / _maxTime * Time.deltaTime));
            _txt.color = new Color(_txt.color.r, _txt.color.g, _txt.color.b, _txt.color.a + (1 / _maxTime * Time.deltaTime));
                if (Input.anyKeyDown)
                {
                    _per._scene += 1;
                    SceneManager.LoadScene(_currentScene+1);

                }
            }
        }
    }
}
