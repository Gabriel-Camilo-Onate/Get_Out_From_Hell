using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetersToMeet : MonoBehaviour
{
    private Player _player;
    public float _distance;
    private DistanceID _dID;
    public Text _text;

    private float _cTime;
    public float _maxTime;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        if (FindObjectOfType<DistanceID>() != null)
            _dID = FindObjectOfType<DistanceID>();
        if(_dID!=null)
        _text = _dID.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        _cTime += Time.deltaTime;
        if (_cTime > _maxTime)
        {
        _distance = _player.transform.position.z- transform.position.z;
            if (_distance < 0)
                _distance = 0;
if(_text!=null)
            _text.text =""+  (int)_distance+"M";
            _cTime = 0;
        }
    }
    
}
