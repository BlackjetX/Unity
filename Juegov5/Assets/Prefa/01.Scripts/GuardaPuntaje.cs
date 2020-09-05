using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardaPuntaje : MonoBehaviour
{

    public static string puntaje="";
    public Text score;
    // Start is called before the first frame update
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntaje=score.text;
    }
}
