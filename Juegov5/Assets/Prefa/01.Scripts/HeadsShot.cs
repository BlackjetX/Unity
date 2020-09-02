using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsShot : MonoBehaviour
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
    public void Head()
    {
        this.Enemigo.GetComponent<Enemigo>().Muerte(5);
    }
}
