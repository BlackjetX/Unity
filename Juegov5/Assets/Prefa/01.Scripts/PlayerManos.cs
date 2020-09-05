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
    public GameObject SonidoFondo;
    public GameObject Recarga;
    public GameObject SonidoHeadShot;
    public GameObject destello;
    public GameObject MuerteCabeza1;
    public Text Balas;
    public Text puntaje;
    int balasCargador;
    int balasReserva;
    int Rabia;


    //para la municion
    public GameObject caja1;
    public GameObject caja2;
    public GameObject caja3;
    //control hordas
    int enemigosSersenados;
    public Text EnemigosSercenadosText;
    int EstadoHorda;
    public GameObject TextoHorda;
    public Text TextoHordaNumero;
  
    public GameObject FirsPerson;
    //este tiene el collider
    //fin municion
    Vector3 inicial;
    Vector3 suma;

    //prueba
    public GameObject enemigoTemporal;
    public GameObject cuerpojugador;

    void Start()
    {
        enemigosSersenados =0;
        EstadoHorda = 0;
        Sonido(this.SonidoFondo.GetComponent<AudioSource>());
        this.balasCargador = 30;
        this.balasReserva = 210;
        this.Rabia = 0;
        this.animaciones = this.GetComponent<Animation>();
        Balas.text = "Balas: " + balasCargador + "/" + balasReserva;
        puntaje.text = "Rabia: " + Rabia;
        CrearEnemigos(150);
        controladorBalas("");
        MedidorRabia(0);

        
    }
    public void sumarMuerteEnemigo()
    {
        this.enemigosSersenados += 1;
    }
  
    void controladorBalas(string modificacionBalas) {

        if (modificacionBalas == "disparo")
        {
            this.balasCargador--;
            Balas.text = "Balas: " + balasCargador + "/" + balasReserva;
        }
        else if (modificacionBalas == "municion")
        {
            if (this.balasReserva + 30 <= 210)
            {
                this.balasReserva += 30;
                Balas.text = "Balas: " + balasCargador + "/" + balasReserva;
            }
            else
            {
                this.balasReserva = 210;
                Balas.text = "Balas: " + balasCargador + "/" + balasReserva;
            }
        }
        else if (modificacionBalas == "recarga")
        {
            if (this.balasReserva > 0 && this.balasCargador < 30)
            {
                print("reload " + "las balas del cargador son " + this.balasCargador);
                Sonido(this.Recarga.GetComponent<AudioSource>());
                int recarga = 30 - this.balasCargador;
                if (this.balasReserva - recarga < 0)
                {
                    print("en la reserva hay" + this.balasReserva);
                    this.balasCargador += this.balasReserva;

                    this.balasReserva = 0;
                }
                else {
                    this.balasCargador += recarga;
                    this.balasReserva -= recarga;
                }

                Balas.text = "Balas: " + balasCargador + "/" + balasReserva;

            }
           
            else if (this.balasReserva <= 0)
            {
                print("se agotaron las balas");
            }

        }
       
        
        

        

    }
    void MedidorRabia(int puntos) {
        this.Rabia += puntos;
        puntaje.text = "Rabia: "+ Rabia;
        print("me actualice");
    }

    // Update is called once per frame
    void Update()
    {
        //recogerMunicionm();
        recogerMunicionm();
        //-------------**-----------//

        //compruebo estado horda
        ControlHordas();
        if (!Input.anyKey)
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
                
                if (this.balasCargador > 0)
                {
                    Disparar();
                    controladorBalas("disparo");
                
                }
                else if (this.balasCargador <= 0) {
                    controladorBalas("recarga");                
                }
                
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("la magia");
               // Magia();
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                print("la recargacion");
                controladorBalas("recarga");
            }   
        }
     
    }

    public void ControlHordas() {

        EnemigosSercenadosText.text = "Zombies " +"\n   "+this.enemigosSersenados;
        if (this.enemigosSersenados == 0)
        {
            CrearEnemigos(36);
            print("cree enemigos");
            this.enemigosSersenados++;
            //this.TextoHorda.SetActive(true);

            GameObject HordaText = Instantiate(this.TextoHorda, this.TextoHorda.transform.position, this.TextoHorda.transform.rotation);
            HordaText.SetActive(true);
            Destroy(HordaText, 5.5f);
           
            


        }
        else if (this.enemigosSersenados == 5)
        {

            this.TextoHordaNumero.text = "2";
            CrearEnemigos(19);
            print("cree enemigos");
            this.enemigosSersenados++;
            GameObject HordaText = Instantiate(this.TextoHorda, this.TextoHorda.transform.position, this.TextoHorda.transform.rotation);
            HordaText.SetActive(true);
            Destroy(HordaText, 5.5f);
        }
        else if (this.enemigosSersenados == 15) {
            this.TextoHordaNumero.text = "3";
            CrearEnemigos(35);
            print("cree enemigos");
            this.enemigosSersenados++;

            GameObject HordaText = Instantiate(this.TextoHorda, this.TextoHorda.transform.position, this.TextoHorda.transform.rotation);
            HordaText.SetActive(true);
            Destroy(HordaText, 5.5f);

        } else if (this.enemigosSersenados == 30) {
            this.TextoHordaNumero.text = "4";
            CrearEnemigos(36);
            print("cree enemigos");
            this.enemigosSersenados++;
            GameObject HordaText = Instantiate(this.TextoHorda, this.TextoHorda.transform.position, this.TextoHorda.transform.rotation);
            HordaText.SetActive(true);
            Destroy(HordaText, 5.5f);


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
                MedidorRabia(50);
                
                print("golpe a la cabeza");

                //saca mensaje
                GameObject impactMuerteCabezaB = Instantiate(this.MuerteCabeza1, this.MuerteCabeza1.transform.position, this.MuerteCabeza1.transform.rotation);
                impactMuerteCabezaB.SetActive(true);
                Destroy(impactMuerteCabezaB, 0.9f);
                //sonido
                Sonido(this.SonidoHeadShot.GetComponent<AudioSource>());

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
            this.suma = new Vector3((float)(Random.Range(20.0f, 50.0f)), (float)0, (float)(Random.Range(-75.0f, 300.0f)));
            this.inicial = this.enemigoTemporal.transform.position;
            GameObject enemigottt = Instantiate(this.enemigoTemporal, inicial + suma, this.enemigoTemporal.transform.rotation);
            enemigottt.SetActive(true);
        }


        for (int i = 0; i < (CantZombie/3); i++)
        {
            this.suma = new Vector3((float)(Random.Range(20.0f, 50.0f)), (float)0, (float)(Random.Range(200.0f, 300.0f)));
            this.inicial = this.enemigoTemporal.transform.position;
            GameObject enemigottt = Instantiate(this.enemigoTemporal, inicial + suma, this.enemigoTemporal.transform.rotation);
            enemigottt.SetActive(true);
        }
        
    }
    void recogerMunicionm()
    {

        RaycastHit ray;
        if (Physics.Raycast(this.FirsPerson.transform.position, this.FirsPerson.transform.forward, out ray, 20f))
        {
            if (ray.collider.gameObject.CompareTag("ammo"))
            {
                if (Input.GetKey(KeyCode.F)) {
                    print("destruire caja 1");
                    controladorBalas("municion");
                    Destroy(caja1.gameObject, 0f);
                }
            }
            if (ray.collider.gameObject.CompareTag("ammo1"))
            {

                if (Input.GetKey(KeyCode.F))
                {
                    print("destruire caja 2");
                    controladorBalas("municion");
                    Destroy(caja2.gameObject, 0f);
                }

            }
            if (ray.collider.gameObject.CompareTag("ammo2"))
            {
                if (Input.GetKey(KeyCode.F))
                {
                    print("destruire caja 3");
                    controladorBalas("municion");
                    Destroy(caja3.gameObject, 0f);
                }

            }

        }
    }


}
