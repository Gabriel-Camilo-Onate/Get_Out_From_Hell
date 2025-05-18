using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looking : MonoBehaviour
{
    public Player _boss;
    // Start is called before the first frame update
    void Start()
    {
        _boss=FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = _boss.transform.position;
    }
}
