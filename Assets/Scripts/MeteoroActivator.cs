using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroActivator : MonoBehaviour
{
    public GameObject _musko;
    // Start is called before the first frame update

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
            _musko.SetActive(true);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
            _musko.SetActive(true);
    }
}
