using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R : MonoBehaviour
{
    // Start is called before the first frame update
    public int contador = 0;

    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
  {
        if(other.name=="key")
        {
            other.GetComponent<AudioSource>().Play();
            print("colisiono " + other.name);
            contador++;
            Destroy(other.transform.parent.gameObject,0.7f);
        }
    
  }

    // Update is called once per frame
    void Update()
    {
        if (this.contador == 3)
        {
            print("Todas las llaves cogidas   ");
        }
        
    }
}
