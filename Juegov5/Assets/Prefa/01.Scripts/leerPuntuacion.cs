using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leerPuntuacion : MonoBehaviour
{
     public Text puntaje;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1366, 768, true);
        puntaje.text=GuardaPuntaje.puntaje.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
