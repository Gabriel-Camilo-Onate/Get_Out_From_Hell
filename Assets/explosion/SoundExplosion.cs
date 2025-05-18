using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundExplosion : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioExplosion;
    
    void Awake()
    {
        audioExplosion.Play();
       

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
