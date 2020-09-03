using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class PlayerManos : MonoBehaviour
{
    // Start is called before the first frame update
    public Animation animaciones;
    public Camera Cam;
    public RaycastHit hit;
    public GameObject Impactoa;
    public GameObject Impactob;
    public GameObject SonidoLacer;
    public GameObject destello;
   


    int Rabia;
    
    public Text puntaje;
    Vector3 inicial;
    Vector3 suma;

    //prueba
    public GameObject enemigoTemporal;
    void Start()
    {
        this.Rabia = 0;
        this.animaciones = this.GetComponent<Animation>();
        CrearEnemigos(15);
        MedidorRabia(0);

    }
    void MedidorRabia(int puntos) {
        this.Rabia += puntos;
        puntaje.text = "Rabia: "+ Rabia;
        print("me actualice");
    }

    // Update is called once per frame
    void Update()
    {
       

        if(!Input.anyKey)
        {
            this.animaciones.CrossFade("Idle");
        }
        else
        {
            if(Input.GetMouseButton(0))
            {
                if(this.animaciones.IsPlaying("SMG_fire1shot"))
                {
                    return;
                }
                this.animaciones.CrossFade("SMG_fire1shot");
                Disparar();
            }
            else
            {
                if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
                {
                    if(!Input.GetKey(KeyCode.LeftShift))
                    {
                        this.animaciones.CrossFade("Run");
                    }if(Input.GetKey(KeyCode.LeftShift))
                    {
                        this.animaciones.CrossFade("Run2");
                        this.animaciones["Run2"].speed = 1.5f;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
               // Magia();
            }
        }
     
    }

    

   /* public void Magia()
    {
        //GameObject.Find("Cyclone").GetComponent<ParticleSystem>().Play();
        GameObject.Find("Meteor Storm").GetComponent<ParticleSystem>().Play();
        
    } */
    public void Disparar()
    {
        Sonido(this.SonidoLacer.GetComponent<AudioSource>());
        GameObject temp2 = Instantiate(this.destello, this.destello.transform.position, destello.transform.rotation);
        temp2.SetActive(true);
        Destroy(temp2, 0.065f);

        if (Physics.Raycast(this.Cam.transform.position, this.Cam.transform.forward, out hit, 1000f))
        {
           
        if(hit.collider.gameObject.name == "Cuerpo")
            {
                GameObject impactoTemp = Instantiate(this.Impactob, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                impactoTemp.SetActive(true);
                Destroy(impactoTemp, 0.5f);
                hit.collider.gameObject.GetComponent<CuerpoS>().Cuerpo();
                MedidorRabia(15);
                print("golpe al cuerpo");
            }
            
            if (hit.collider.gameObject.name == "Cabeza")
            {
                GameObject impactoTempB = Instantiate(this.Impactob, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                impactoTempB.SetActive(true);
                Destroy(impactoTempB, 0.5f);
                hit.collider.gameObject.GetComponent<HeadsShot>().Head();
                MedidorRabia(500);
                print("golpe a la cabeza");
            }
            else {
                GameObject impactoTemp = Instantiate(this.Impactoa, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                impactoTemp.SetActive(true);
                Destroy(impactoTemp, 0.5f);
            }
            
        }
    }

    public void Sonido(AudioSource Sonido)
    {
       // if (!Sonido.isPlaying)//si no se esta reproduccionedo activa el sonido
        //{
            Sonido.Play();
        //}
    }

    public void CrearEnemigos(int CantZombie)
    {
        //this.suma = new Vector3((float)160.1, (float)0.1, (float)0.1);
        //this.suma = new Vector3((float)16, (float)0, (float)0);
        for(int i = 0; i < CantZombie; i++) { 
            this.suma = new Vector3((float)(Random.Range(-9.0f, 16.0f)), (float)0, (float)(Random.Range(0.0f, 300.0f)));
            this.inicial = this.enemigoTemporal.transform.position;
            GameObject enemigottt = Instantiate(this.enemigoTemporal, inicial + suma, this.enemigoTemporal.transform.rotation);
            enemigottt.SetActive(true);
        }


        for (int i = 0; i < (CantZombie/3); i++)
        {
            this.suma = new Vector3((float)(Random.Range(-9.0f, 16.0f)), (float)0, (float)(Random.Range(300.0f, 300.0f)));
            this.inicial = this.enemigoTemporal.transform.position;
            GameObject enemigottt = Instantiate(this.enemigoTemporal, inicial + suma, this.enemigoTemporal.transform.rotation);
            enemigottt.SetActive(true);
        }
    }

}
