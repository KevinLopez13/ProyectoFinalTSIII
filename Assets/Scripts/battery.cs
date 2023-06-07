using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{
    
    public float output_voltage {get;} = 9.0f;
    public float current {get;} = 0.170f; // 170mA
    // public float current_load {get;} = 0.0f;


    public float getCurrent(){
        return 0.0f;
    }
}
