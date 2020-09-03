using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoS : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemigo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Cuerpo()
    {
        this.Enemigo.GetComponent<Enemigo>().Muerte(0);
    }
}
