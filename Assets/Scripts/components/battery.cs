using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simulates the behavior of a battery.
*/
public class battery : MonoBehaviour
{
    
    public float? input_voltage = 0.0f;
    public float? output_voltage = 0.0f;
    public float supply_voltage {get; set;} = 9.0f;
    public float current {get;} = 0.170f; // 170mA
    // public float current_load {get;} = 0.0f;

    public float? getOutputVoltage(){
        return input_voltage == null ? null : output_voltage;
    }

    public void setInputVoltage(float? voltage){
        input_voltage = voltage;
        output_voltage = input_voltage == null ? null : supply_voltage;
    }

    public float getCurrent(){
        return 0.0f;
    }
}
