using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   


public class Enemigo : MonoBehaviour
{
    NavMeshAgent Agente;
    public GameObject Objetivo;//a quien va a  perseguir

    Vector3 inicial;
    Vector3 suma;

    public bool Obstaculo;
    public int impato;
   
    public GameObject enemigoTemporal;
    public RaycastHit hit;

    // Start is called before the first frame update

    int cantidad = 0;
    void Start()
    {
        impato = 0;
        this.inicial = this.gameObject.transform.position;
        print("dimenciones"+inicial);
        //this.Objetivo = GameObject.Find("ThirdPersonController");
        this.Agente = this.gameObject.GetComponent<NavMeshAgent>();

        

    }

    // Update is called once per frame
    void Update1()
    {

       


        NavMeshHit hit;
        NavMeshHit hit2;
        this.Obstaculo = NavMesh.Raycast(this.transform.position,this.Objetivo.transform.position, out hit, NavMesh.AllAreas);
        Debug.DrawLine(this.transform.position, this.Objetivo.transform.position, this.Obstaculo?Color.red : Color.green);
        if (!this.Obstaculo)
        {
            Animacion(1);
            Desplazar(this.Objetivo.transform.position);
            
        }
        else
        {

            Animacion(1);
            Desplazar(this.inicial);
            
           NavMesh.Raycast(this.transform.position, this.inicial, out hit2, NavMesh.AllAreas);
            print(hit2.distance);
            if ( this.Agente.remainingDistance < 1)
            {
                Animacion(2);
                //Atacar(1);
                print("llego");
            }    
        }

        
    }


    void Update()
    {

        

        NavMeshHit hit;
        this.Obstaculo = NavMesh.Raycast (this.transform.position, this.Objetivo.transform.position, out hit, NavMesh.AllAreas);
        Debug.DrawLine(this.transform.position, this.Objetivo.transform.position, this.Obstaculo ? Color.red : Color.green);

        if (!this.Obstaculo)//si no hay obstaculo en la linea de vission me persigue
        {
            float distancia = Vector3.Distance(this.transform.position, this.Objetivo.transform.position);
            if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Golpe")) 
            {
                //transform.LookAt(this.Objetivo.transform);
                this.Agente.isStopped = false;
                Desplazar(this.Objetivo.transform.position);
                Animacion(1);
            }
            if(distancia<=2.5f)//estoy muy cerca
            {
                this.Agente.isStopped = true;
                Animacion(3);
                ReproducirSonidos(GetComponents<AudioSource>()[0]);
            }

        }
        else
        {
            Desplazar(this.inicial);
            if (this.Agente.remainingDistance < 2)
            {
                Animacion(2);
                //Atacar(1);
                
               
               //print("llego");
            }
        }
    }

    void Animacion(int estado)
    {
        this.GetComponent<Animator>().SetInteger("Estado", estado);
    }
    void Atacar(int atacar)
    {
        this.GetComponent<Animator>().SetInteger("Atacar", atacar);
    }

    void Desplazar(Vector3 destino)
    {
        this.Agente.destination=destino;
    }

    public void  ReproducirSonidos(AudioSource Sonido)
    {
        if (!Sonido.isPlaying)//si no se esta reproduccionedo activa el sonido
        {
            Sonido.Play();
        }
    }  
    

    public void  Muerte(int Muerte)
    {
        impato++;
        if (impato == 5) { 
        //this.GetComponent<Animator>().SetInteger("Dead",1);
        Destroy(this.gameObject, 0f);
        print("me mataron");
        }
        if(Muerte==5)
        {
            this.GetComponent<Animator>().SetInteger("Dead", 1);
            Destroy(this.gameObject, 0f);
        }
    }




   }
