using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municion : MonoBehaviour
{
    public int contador = 0;
    //public GameObject objectivoQueQuiere;
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {/*
        if (other.name == "AmmoBox")
        {
            //other.GetComponent<AudioSource>().Play();
            print("colisiono " + other.name);
            contador++;
            Destroy(other.transform.parent.gameObject, 0.7f);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {/*
        Debug.DrawLine(this.transform.position, this.objectivoQueQuiere.transform.position, Color.blue);
        if (this.contador == 3)
        {
            print("Todas las municiones recogidas");
        }
        */
    }

    public void DestruirMunicion()
    {
        Destroy(this.gameObject, 0f);
    }
}
