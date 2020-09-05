using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class cambiar_escena : MonoBehaviour
{   
   
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1366, 768, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(){
        this.GetComponents<AudioSource>()[1].Play();
        SceneManager.LoadScene("nivel2");
    }

    public void about(){
        this.GetComponents<AudioSource>()[1].Play();
        SceneManager.LoadScene("about");
    }

    public void mainmenu(){
        this.GetComponents<AudioSource>()[1].Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void howtoplay(){
        this.GetComponents<AudioSource>()[1].Play();
        SceneManager.LoadScene("howtoplay");
    }

    /*void reproducirSonido(AudioSource sonido){
        if(!sonido.isPlaying){
            sonido.Play();
        }
    }*/
}
