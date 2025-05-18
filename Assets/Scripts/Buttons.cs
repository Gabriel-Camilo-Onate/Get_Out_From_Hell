using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public int _escena;
    public Button _thisOneB;

    public Image _thisOne;
    public Text _text;
    public Text _text2;
    public Panelsmanasha _p;
    public Persistente _per;
    public int _i;
    public AudioSource _as;
    // Start is called before the first frame update
    void Start()
    {
        _thisOne = GetComponent<Image>();
        _thisOneB = GetComponent<Button>();
        _per = FindObjectOfType<Persistente>();
if(_per!=null)
        _escena = _per._scene;
        if (GetComponent<AudioSource>() != null)
        {
            _as = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Sound()
    {
        _as.Play();
    }
    public void ReLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(_escena + 1);

    }
    public void TutorialSiguiente()
    {

        _thisOneB.interactable = false;


    }
    public void PlayDvd()
        {
        SceneManager.LoadScene(3);
        _per._scene = 3;

    }
    public void Play()
    {

    }
    public void Tutorial()
    {

    }
    public void GoTutorial()
    {
        SceneManager.LoadScene(2);
        _per._scene = 2;

    }
    public void Reload()
    {
        SceneManager.LoadScene(_per._scene);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        _per._scene = 0;
    }
    public void SiguienteNivel()
    {
        SceneManager.LoadScene(_per._scene);
       
    }
    public void EXIT()
    {
        Application.Quit();
    }
}
