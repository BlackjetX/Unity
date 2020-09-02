using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;

public class Java : MonoBehaviour
{
    // Start is called before the first frame update
    public int valor12;
    void Start()
    {
       //this.valor12 = Random.Range(1,254);
    }

    // Update is called once per frame
    void Update()
    {
        
        this.gameObject.transform.Rotate(Vector3.up*100*Time.deltaTime);
    }
}
