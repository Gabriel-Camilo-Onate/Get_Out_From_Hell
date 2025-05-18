using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Persistente : MonoBehaviour
{
    public int _scene;
    public GameObject _selected;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _selected = EventSystem.current.currentSelectedGameObject;
    }
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }


    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(_selected);
        }
        else
        {
            _selected = EventSystem.current.currentSelectedGameObject;
        }

    }
}
