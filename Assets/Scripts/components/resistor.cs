using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simulates the behavior of a resistor.
*/
public class resistor : MonoBehaviour
{
    public float? input_voltage = 0.0f;
    public float? output_voltage = 0.0f;
    public float voltage {get; set;} = 0.0f;
    public float resistence {get; set;} = 1000; // 1 KOhm by default
    public float current {get; set;} = 0.0f;
    
    public void setInputVoltage(float? volt){
        input_voltage = volt;
        voltage = current * resistence;
        output_voltage = input_voltage == null ? null : input_voltage - voltage;
    }

    public float? getOutputVoltage(){
        return input_voltage == null ? null : output_voltage;
    }
    
}
