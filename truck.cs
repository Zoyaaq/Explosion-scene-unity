using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truck : MonoBehaviour
{
    public GameObject industrytruck;
   

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(industrytruck);
        }


    }
}  

