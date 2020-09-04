using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirMunicion : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject municion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestruirMunicionMetodo()
    {
        Destroy(municion,0f);
    }
}
