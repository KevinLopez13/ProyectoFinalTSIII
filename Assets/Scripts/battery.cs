using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{
    
    public float positive_pin = 9.0f;
    public float negative_pin = 0.0f;

    float getVoltage(){
        return positive_pin;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
