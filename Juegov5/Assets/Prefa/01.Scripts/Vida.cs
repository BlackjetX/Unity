using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{

    // Start is called before the first frame update
    float salud;
    public GameObject barraSangre;
    //public GameObject gameOver;

    //botiquinees
    public GameObject Aid1;
    public GameObject Aid2;

    void Start()
    {
        this.salud = 1;    
    }

    void OnTriggerEnter(Collider other)
    {
        
        if ((other.name== "Cabeza")||((other.name== "Cuerpo")))
        {
            //print("bajar sangre");
            this.salud=this.salud-0.1f;
            this.barraSangre.GetComponent<Image>().fillAmount=this.salud;
            if(this.salud<=0)
            {
                //this.gameOver.SetActive(true);
                SceneManager.LoadScene("Ganaste");
            }
        }
        if(other.name=="AmmoBox")
        {

            //other.gameObject.GetComponent<DestruirMunicion>().DestruirMunicionMetodo();
            //Destroy(other, 0f);
            print("Recoge municion");
        }
        if (other.tag == "botiquin1") {
         
                this.salud = this.salud + 0.36f;
                this.barraSangre.GetComponent<Image>().fillAmount = this.salud;
                Destroy(Aid1);
            
            
        }
        if (other.tag == "botiquin2")
        {
           
                this.salud = this.salud + 0.36f;
                this.barraSangre.GetComponent<Image>().fillAmount = this.salud;
                Destroy(Aid2);


        }
        if (other.name == "Portal") {
            SceneManager.LoadScene("GameOver");
        }

        print("name "+ other.name);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
