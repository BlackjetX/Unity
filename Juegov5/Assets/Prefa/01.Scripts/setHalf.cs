using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setHalf : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float factor = 0.5f;
    void Start()
    {
            Screen.SetResolution(Mathf.CeilToInt(Screen.currentResolution.width*factor),
            Mathf.CeilToInt(Screen.currentResolution.width * factor),true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
