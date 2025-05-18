using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator _aC;
    private Brain _brain;
    public Rigidbody _rb;
    public bool _runing;
    public bool _jumping;
    public bool _sliding;
    public bool _isDead;
    private bool _lOr;
    public float _speed;
    public float _stepSpeed;
    public float _speedRegulator;
    public float _speedDecrease;
    private const int _constZero= 0;
    private Vector3 _runV;
    public float _runCurrentTime;
    public float _runMaxTime;
    public float _runUmbral;
    public float _maxSpeed;
    public float _horizontalSpeed;
    public float _jumpForce;
    public AudioSource[] _audioS;
    public float _audioCTime;
    public float _audioMaxTime;
    public float _audioMaxTimeOut;
    public bool _win;

    public bool _walkeo;
    public bool _lateraleo;
    public bool _jumpeo;
    public bool _agacho;

    private Brain2 _brain2;

    public bool _isInTuto;

    public Persistente _per;
    public Image[] _bti;

    public Button[] _bt;
    public Text[] _bttext;
    public Image _img;
    public MetersToMeet _mtM;

    public float _cft;
    public float _cmt;
    public Image _susto;

    public ParticleSystem _fireStep;
    public bool _canfireWalking;
    public bool _fireWalking;
    public Transform[] _steponeortwo;
    public Image _nota;
    public Text _notat;

    private float _cReadTime;
    private float _mReadtime = 1.5f;

    public Image _fireBar;
    public float _maxFire;
    public float _actualFire;
    public float _fireDecrement;
    public float _fireRecover;
    public float _firect;
    public float _firemaxt;

    public float _fireOrMaxSpeed;
    public float _fireMaxSpeedPlus;
    public float _fireSpeedPlus;

    public bool _wallTouch;
    public bool _obstacleTouch;


    public bool _enhielo;
    public bool _cando;
    public Transform _final;
    public float _minrange;
    public float _speed2;

    public float _ct3;
    public float _mt3;
    public bool _finalOne;
    public Camera _cam;
    public Animator _camanim;
    public Text _ratDistance;
    public AudioClip _levan;
    public Image _finalPanel;
    public Animator _credits;
    public bool _anegro;
    public float _ct4;
    public float _mt4;
    public bool _fireJump;
    public Animator _rw;
    public Animator _lw;
    public AudioSource _pedo;
    public float _fireJumpCost;
    public GameObject _pedodefuegoparticula;
    public bool _canFireJump;
    public Vector3 _fireJumpPawa;
    public int _floorCounter;
    void Start()
    {
        _aC = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _per = FindObjectOfType<Persistente>();
        _mtM = FindObjectOfType<MetersToMeet>();
        _cam = FindObjectOfType<Camera>();
        _camanim = _cam.GetComponent<Animator>();
        _cando = true;
        if (_isInTuto)
        {
            _brain2 = new Brain2
            { _player = this, _panelManasha = GetComponent<Panelsmanasha>() };
        }
        else
        {
            _brain = new Brain { _player = this };
        }

        _runV.x = _constZero;
        _runV.y = _constZero;
        _fireOrMaxSpeed = _maxSpeed;
        if (_canfireWalking)
        {
            _actualFire = _maxFire;

        }
        else
        {
            if(_fireBar!=null)
            _fireBar.enabled = false;
        }

    }

    void Update()
    {
        if (_anegro)
        {
            ANEGRO();
        }

        if (!_isDead && _cando)
        {
            if (_isInTuto)
            {
                _brain2.ListenKeys();
            }
            else
            {
                _brain.ListenKeys();
            }
            Run();
        }
        else
        {

        }
        Harto();
        if (_win && _per._scene < 10)
        {
            Reading();
        }
        if (_win && _per._scene >= 10)
        {
            FinalClip();
        }
        FireBar();
        if (_sliding)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        }
    }
    public void Harto()
    {
        if (_mtM != null)
        {

        if(_mtM._distance<10)
        {
            //_audioS[9].Play();
        }
        if (_mtM._distance < 6)
        {
            _cft += Time.deltaTime;
            if (_cft >= _cmt)
            {

            }
        }
        }
    }
    public void FireWalk()
    {
        if (_canfireWalking)
        {
            _fireWalking = true;
        }
    }
    public void Run()
    {
        
        _runV.z = _speed * _speedRegulator;
        _runCurrentTime += Time.deltaTime;
        if (_runCurrentTime >= _runMaxTime)
        {
            _speed -= _speedDecrease;
            if (_speed < _constZero)
                _speed = _constZero;
            _runCurrentTime = _constZero;
        }
        Checkrun();
    }
    public void TimeToSound()
    {
            if (_audioS[1].isPlaying)
                return;
        _audioCTime += Time.deltaTime;
        if (_audioCTime >= _audioMaxTime)
        {
                Sound();
                _audioCTime = _constZero;
        }
    }
    public void Sound()
    {
        for (int i = 0; i < 2; i++)
        {
            _audioS[i].Play();
          
        }
    }
    public void StopSound()
    {
        if (!_audioS[0].isPlaying)
            return;
        _audioCTime += Time.deltaTime;
        if (_audioCTime >= _audioMaxTimeOut)
        {
                _audioS[1].Stop();

        }

        if (_audioCTime >= _audioMaxTimeOut *10)
        {
            _audioS[0].Stop();
            _audioCTime = _constZero;

        }
    }
    public void Checkrun()
    {
        if (_speed >_constZero)
        {
            if (_fireJump)
                return;
            _runing = true;
            _aC.SetBool("_isRuning", _runing);
            if (_enhielo && !_fireWalking)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, _runV.z);//velocidades a modificar con if cuando lo haya hecho en x
            }
            else
            {
                _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, _runV.z);//velocidades a modificar con if cuando lo haya hecho en x
            }
            TimeToSound();
        }
        else
        {
            if (_fireJump)
                return;
            _runing = false;
            _aC.SetBool("_isRuning", _runing);
            if (_enhielo && !_fireWalking && _rb.velocity.z>0.1f)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, 0.5f);//velocidades a modificar con if cuando lo haya hecho en x

            }
            else
            {
                _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, _constZero);//velocidades a modificar con if cuando lo haya hecho en x
            }
            StopSound();
        }
        if (!_sliding)
        {
            _aC.SetBool("_isSliding", _sliding);
        }
        if (_jumping)
        {
            _aC.SetBool("_isJumping", _jumping);
        }
        if (_sliding)
        {
            gameObject.layer = 10;
        }
        else
        {
            gameObject.layer = 9;
        }

    }
   public void Step(bool _leftOrRight)
    {
        if (_speed <= _constZero)
        {
        _speed += _stepSpeed;
            _lOr = _leftOrRight;
        }
        else
        {
            if (_leftOrRight!=_lOr)
            {
                _speed += _stepSpeed;
                   _lOr = _leftOrRight;
            }
        }
        
        if (_speed >= _maxSpeed)
        {
            if (_fireJump)
                return;
            _speed = _maxSpeed;
        }
        // aca instanciar el ps
        if (_fireWalking && _actualFire>_fireDecrement)
        {
            if(!_jumping)
            {

            if (_leftOrRight)
            {

            Instantiate(_fireStep, _steponeortwo[1].position, transform.rotation);
            }
            else
            {
                Instantiate(_fireStep, _steponeortwo[0].position, transform.rotation);

            }
            //hacer cosas del firewalking
            _maxSpeed = _fireMaxSpeedPlus;
            _firect += Time.deltaTime;
            if (_firemaxt <= _firect)
            {
            _actualFire -= _fireDecrement;
            _speed += _fireSpeedPlus;
                _firect = _constZero;
                if (_actualFire < _constZero)
                    _actualFire = _constZero;
            }
        }
            }
        
    }
    public void FireBar()
    {
        if (_actualFire <= _fireDecrement)
            _fireWalking = false;
        if(_fireBar!=null)
        _fireBar.fillAmount =  _actualFire/ _maxFire ;
        _firect += Time.deltaTime;
        if (_firemaxt <= _firect)
        {
            if (!_fireWalking && _actualFire < _maxFire)
                _actualFire += _fireRecover;
            if (_actualFire > _maxFire)
                _actualFire = _maxFire;
            _firect = _constZero;
        }
        if (!_fireWalking)
        {
            _maxSpeed = _fireOrMaxSpeed;
        }
    }

    public void LeftAndRightMovment(float _dir)
    {
        if (!_aC.GetBool("_isRuning"))
            return;
        if (_wallTouch && transform.position.x > _constZero && _dir > _constZero)
            return;
        if (_wallTouch && transform.position.x < _constZero && _dir < _constZero)
            return;
        if (_enhielo && !_fireWalking)
        {
            if(_rb.velocity.x<1 && _rb.velocity.x >-1)
                _rb.velocity = new Vector3(_dir * _horizontalSpeed, _rb.velocity.y, _rb.velocity.z);

        }
        else
        {
        _rb.velocity = new Vector3(_dir * _horizontalSpeed, _rb.velocity.y, _rb.velocity.z);
        }
    }
    public void Slide()
    {
        if (_sliding||_jumping)
            return;
        Vector3 pos = transform.position;
        _sliding= true;
        _aC.SetBool("_isSliding", _sliding);
        _audioS[4].Play();
        _rb.useGravity = false;
        transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
    }
    public void Jump()
    {
        if (_jumping)
        {
            FireJump();
        }
        if (_jumping ||_fireJump== true || _sliding)
            return;
        _jumping = true;
        _aC.SetBool("_isJumping", _jumping);
        _rb.AddForce(_constZero, _jumpForce, _constZero,ForceMode.Impulse);
            _audioS[3].Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
       

            if (collision.gameObject.layer == 20)
        {
            _enhielo = true;
        }
        if (collision.gameObject.layer == 8)
        {
            _floorCounter++;
            if (_jumping)
            {
                _jumping = false;
                _lw.SetBool("_batida", false);
                _rw.SetBool("_batida", false);
                _aC.SetBool("_isJumping", _jumping);
            }

        }
   
        if (collision.gameObject.layer == 12)
        {
            if (_win)
                return;
            gameObject.layer = 10;

            _audioS[6].Stop();
            _win = true;
            if(_fireBar!=null)
                _fireBar.enabled = false;
            if (_nota != null)
            {
                _nota.enabled = true;
                _notat.enabled = true;
            }
          
           

        }
        if (collision.gameObject.layer == 18)
        {
            _wallTouch = true;
        }
        if (collision.gameObject.layer == 19)
        {
            _obstacleTouch = true;
            if (_win)
            {
               Destroy(collision.gameObject);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            Destroy(other.gameObject);
            Death();
        }
        if (other.gameObject.layer == 12)
        {
            if (_win)
                return;
            gameObject.layer = 10;

            _audioS[6].Stop();
            _win = true;
            if (_fireBar != null)
                _fireBar.enabled = false;
            if (_nota != null)
            {
                _nota.enabled = true;
                _notat.enabled = true;
            }
        }
        }
    public void Reading()
    {
        if (!_isInTuto)
        {

        _cReadTime += Time.deltaTime;
        if (_cReadTime >= _mReadtime)
        {


        if (Input.anyKeyDown)
        {
            _per._scene += 1;
            if (_per._scene > 10)
                _per._scene = 0;

                if (_per._scene == 9)
                {
                    SceneManager.LoadScene(9);
                }
                else
                    {
            SceneManager.LoadScene(1);
                    }
        }
        }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                _per._scene += 1;
                if (_per._scene > 9)
                    _per._scene = 0;
                SceneManager.LoadScene(1);
            }
        

    }
}
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 20)
        {
            _enhielo = true;
        }
        if (collision.gameObject.layer == 8)
        {
            if (_jumping)
            {
            _jumping = false;
                _aC.SetBool("_isJumping", _jumping);
                _pedodefuegoparticula.SetActive(false);
            }
            _fireJump = false;


        }
        if (collision.gameObject.layer == 18)
        {
            _wallTouch = true;
        }
        if (collision.gameObject.layer == 19)
        {
            _obstacleTouch = true;

        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _floorCounter--;
            if (!_jumping && transform.position.y>0)
            _jumping = true;
            if(_fireJump)
            _pedodefuegoparticula.SetActive(true);

        }
        if (collision.gameObject.layer == 18)
        {
            _wallTouch = false;
        }
        if (collision.gameObject.layer == 19)
        {
            _obstacleTouch = false;
        }
        if (collision.gameObject.layer == 19)
        {
            _enhielo = false;
        }
        }

        public void Death()
    {
        if (_isDead)
            return;
        _isDead = true;
        _aC.SetBool("_isDead", true);
        if(_fireBar!=null)
        _fireBar.enabled = false;
        _bt[0].enabled = true;
        _bt[1].enabled = true;
        _bttext[0].enabled = true;
        _bttext[1].enabled = true;
        _bti[0].enabled = true;
        _bti[1].enabled = true;

        _img.enabled = true;
        _audioS[6].Stop();
        _audioS[5].Play();
        _audioS[7].Play();
    }
    
    public void FinalClip()
    {
        _ct3 += Time.deltaTime;
        _cando = false;
        if (_fireBar != null)
            _fireBar.enabled = false;
        _mtM._text.enabled = false;
        _ratDistance.enabled = false;
        _rb.velocity = new Vector3(0, 0, 0);
        if (_ct3 > _mt3)
        {

            _audioS[1].Stop();
            _audioS[2].Stop();
            _audioS[0].Stop();
            _audioS[6].Stop();


            _camanim.SetBool("finalone", true);
        }
        if (_ct3 > 6)
        {

            if (!_audioS[4].isPlaying)
            {
            _audioS[4].clip = _levan;
            _audioS[4].volume=0.2f;
            _audioS[4].Play();
                _aC.SetBool("_isdancing", true);
            }
        }
        if (_ct3 > 10)
        {
            _credits.enabled = true;
        }
        if (_ct3 > 32)
        {
            if (Input.anyKeyDown)
            {
                _anegro = true;
            }
        }


            if (Vector3.Distance(transform.position, _final.position) <= _minrange)
        {
        transform.position = _final.position;
            _runing = false;
            _aC.SetBool("_isRuning", _runing);
            
            _finalOne = true;
        }
        else
        {
        transform.position += (_final.position - transform.position).normalized * _speed2 * Time.deltaTime;
        }
    }
    public void ANEGRO()
    {
        _finalPanel.color = new Color(_finalPanel.color.r, _finalPanel.color.g, _finalPanel.color.b, _finalPanel.color.a + (1 * Time.deltaTime));
        _ct4 += Time.deltaTime;
        if (_ct4 >= 2)
        {
            if (_per._scene > 8)
                _per._scene = 0;
            SceneManager.LoadScene(_per._scene);

        }
    }
    public void FireJump()
    {
        if (_fireJump || !_canFireJump || _actualFire<_fireJumpCost)
        {
            return;
        }
        _fireJump = true;
        _actualFire -= _fireJumpCost;
       
        

        _lw.SetBool("_batida", true);
        _rw.SetBool("_batida", true);
        _pedo.Play();
        _pedodefuegoparticula.SetActive(true);
        _rb.AddForce(_fireJumpPawa, ForceMode.Impulse);
        
       
    }

}
