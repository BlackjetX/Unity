using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiar_escena : MonoBehaviour
{
    public GameObject sonidos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jugar(){
        //GetComponents<AudioSource>()[0].Play();
        this.sonidos.GetComponents<AudioSource>()[1].Play();
        SceneManager.LoadScene("nivel1");
    }

    public void creditos(){
        //reproducirSonido(GetComponents<AudioSource>()[0]);
        //GetComponents<AudioSource>()[0].Play();
        this.sonidos.GetComponents<AudioSource>()[1].Play();
        SceneManager.LoadScene("creditos");
    }

    public void inicio(){
        //reproducirSonido(GetComponents<AudioSource>()[0]);
        //GetComponents<AudioSource>()[0].Play();
        this.sonidos.GetComponents<AudioSource>()[1].Play();
        SceneManager.LoadScene("inicio");
    }

    void reproducirSonido(AudioSource sonido){
        if(!sonido.isPlaying){
            sonido.Play();
        }
    }
}
