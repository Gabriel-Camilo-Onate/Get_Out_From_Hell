using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Panelsmanasha : MonoBehaviour
{
    public Player _p;

    public Image _image;
    public Text[] _text;
    public float _waitTime;
    private float _cwaitTime;
    public float _cTime;
    public float _maxTime;
    private bool _ended;

    private float _ct;
    public float _mt;
    public AudioSource _as;
    public int _iTutorial;
    public AudioClip[] _ac;


    public bool _canStep;
    public bool _canLateral;
    public bool _canJump;
    public bool _canAgacharse;
    public bool _walkeo;
    public bool _ladeo;
    public bool _jumpeo;
    public bool _seagacho;
    public bool _anim;

    private float _animcT;
    public float _animmT;

    public Camera _cam;

    public Transform[] _tp;
    private int _itp;

    public float minRange;
    public float rotSpeed;
    public float _tpspeed;

    public bool _stepone;
    public bool _steptwo;

    public bool _sumoneo;
    public GameObject _batallon;



    public float _speed;
    public float _timeToArrive;
    public float _timeToArrive2;
    public Vector2 _d;
    public Vector2 _position;
    public float _cTime2;
    public RectTransform rectTransform;
    private Vector2 _targetP = new Vector2(0, 450);
    private bool _doed;
    private Vector2 _inipos = new Vector2(0, -450);
    private Animator _animxd;
    // Start is called before the first frame update
    void Start()
    {
        _iTutorial = 0;
        _cam = FindObjectOfType<Camera>();
        _animxd = _cam.GetComponent<Animator>();
        _p = GetComponent<Player>();
        _canStep = true;
        _canLateral = false;
        _canJump = false;
        _canAgacharse = false;
        _walkeo = false;
        _ladeo = false;
        _jumpeo = false;
        _doed = true;
        rectTransform = _image.GetComponent<RectTransform>();
        _position = rectTransform.anchoredPosition;
        _d = _targetP - _position;
        _speed = _d.y / _timeToArrive2;

    }

    // Update is called once per frame
    void Update()
    {

        First();
        if (_ended)
            Movardo();
        if(_anim)
        Anim();
        if (_ended)
            Autorial();
    }

    public void Movardo()
    {
        if (!_doed)
        {

            _d = _targetP - _position;
         
            if ( _position.y != _targetP.y)
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
    public void ResetPanel()
    {
        _doed = false;
        _position.y = _inipos.y;
        rectTransform.anchoredPosition = _position;
        _cTime2 = 0;
    }
    public void CameraInn()
    {
            if (Vector3.Distance(_cam.transform.position, _tp[_itp].position) <= minRange)
            {
                _stepone = true;
                _itp++;
            }
            _cam.transform.position += (_tp[_itp].position - _cam.transform.position).normalized * _tpspeed * Time.deltaTime;
    }
    public void CameraOut()
    {
            if (Vector3.Distance(_cam.transform.position, _tp[_itp].position) <= minRange)
            {
                _steptwo = true;
            }
            _cam.transform.position += (_tp[_itp].position - _cam.transform.position).normalized * _tpspeed * Time.deltaTime;
    }
    public void Rotation()
    {
        _animxd.SetBool("rotation", true);
        
       
    }
   
        public void Anim()
        {
        if (!_sumoneo)
        {
            Instantiate(_batallon, new Vector3(0, 0, 130),transform.rotation);
            _sumoneo = true;
        }
        if (!_stepone)
        {
            Rotation();
            CameraInn();
        }

        if (_stepone)
        {
            _animcT += Time.deltaTime;
            if(_animcT>= _animmT)
            {
                if (!_steptwo)
                {
                    _animxd.SetBool("rotation",false);

                    CameraOut();
                }
                else
                {
                 _anim = false;
                 ITutorial();
                }

            }
        }

        }


    public void Autorial()
    {
        if (!_as.isPlaying && _iTutorial<3)
        {
            ITutorial();

        }
        if (!_as.isPlaying && _iTutorial ==11)
            ITutorial();


    }

    public void ITutorial()
    {
        _iTutorial++;

        switch (_iTutorial)
        {


            case (1):

                _text[0].enabled = false;
                _text[1].enabled = true;

                _as.clip = _ac[0];
                _as.Stop();
                _as.Play();
                break;

            case (2):
                _text[0].enabled = false;
                _text[1].enabled = false;

                _text[2].enabled = true;
                _as.clip = _ac[1];
                _as.Stop();
                _as.Play();

                break;

            case (3):
                _doed = false;
                _text[0].enabled = false;
                _text[1].enabled = false;
                _text[2].enabled = false;
                _text[3].enabled = true;
                _as.clip = _ac[2];
                _as.Stop();
                _as.Play();

                break;


            case (5):
                _text[0].enabled = false;
                _text[1].enabled = false;
                _text[2].enabled = false;
                _text[3].enabled = false;
                ResetPanel();

                _text[4].enabled = true;
                _as.clip = _ac[3];
                _as.Stop();
                _as.Play();
                _canLateral = true;

                break;



            case (7):
                _text[4].enabled = false;
                ResetPanel();


                _text[5].enabled = true;
                _as.clip = _ac[4];
                _as.Stop();
                _as.Play();

                _canJump = true;
                break;



            case (9):

                _text[5].enabled = false;
                ResetPanel();

                _text[6].enabled = true;
                _as.clip = _ac[5];
                _as.Stop();
                _as.Play();
                _canAgacharse = true;

                break;

            case (11):
                _text[6].enabled = false;
                _position.y = 0;
                rectTransform.anchoredPosition = _position;

                _p._audioS[1].Stop();
                _p._audioS[6].Stop();
                _canStep = false;
                _canLateral = false;
                _canJump = false;
                _canAgacharse = false;

                _image.enabled = true;
                _text[7].enabled = true;
                _as.clip = _ac[6];
                _as.Stop();
                _as.Play();


                break;
            case (12):

                _text[7].enabled = false;

                _image.enabled = false;

                _as.clip = _ac[7];
                _as.Stop();
                _as.Play();
                _anim = true ;
                break;
            case (13):
                _canStep = true;
                _canLateral = true;
                _canJump = true;
                _canAgacharse = true;
                break;

        }
    }

    public void First()
    {
        if (_ended)
            return;
        _ct += Time.deltaTime;
        if (_ct >= _mt)
        {


            _cTime += Time.deltaTime;

            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a + (1 / _maxTime * Time.deltaTime));
            _text[0].color = new Color(_text[0].color.r, _text[0].color.g, _text[0].color.b, _text[0].color.a + (1 / _maxTime * Time.deltaTime));
            if (_cTime >= _maxTime / 4 && !_as.isPlaying)
            {

                _as.Play();

            }
            if (_cTime >= _maxTime)
            {
                _ended = true;
                _cTime = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            if (_walkeo)
                return;
            _walkeo = true;
            Destroy(other.gameObject);
            _iTutorial = 4;
            ITutorial();

        }
        if (other.gameObject.layer == 14)
        {
            if (_ladeo)
                return;
            _ladeo = true;
            Destroy(other.gameObject);
            _iTutorial = 6;

            ITutorial();

        }
        if (other.gameObject.layer == 15)
        {
            if (_jumpeo)
                return;
            _jumpeo = true;
            Destroy(other.gameObject);

            _iTutorial = 8;
            ITutorial();

        }
        if (other.gameObject.layer == 16)
        {
            if (_seagacho)
                return;
            _seagacho = true;
            Destroy(other.gameObject);
            _iTutorial = 10;

            ITutorial();

        }
    }
}
