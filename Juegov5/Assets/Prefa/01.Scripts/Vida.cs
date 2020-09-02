using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{

    // Start is called before the first frame update
    float salud;

    void Start()
    {
        this.salud = 1;    
    }

    void OnTriggerEnter(Collider other)
    {
        print("bajar sangre");
        if (other.name== "LeftHand")
        {
            print("bajar sangre");
            this.salud=this.salud-0.2f;
            if(this.salud<=0)
            {
                print("Game Over");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
