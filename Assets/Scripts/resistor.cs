using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resistor : MonoBehaviour
{
    public float input_voltage = 0.0f;
    public float output_voltage = 0.0f;
    public float voltage {get; set;} = 0.0f;
    public float resistence {get; set;} = 1000; // 1 KOhm
    public float current {get; set;} = 0.0f;
    // public float current_load {get;} = 0.0f;
    
    public void setInputVoltage(float volt){
        input_voltage = volt;
        voltage = current * resistence;
        output_voltage = input_voltage - voltage;
        // Debug.LogWarning("Update resistor... in: " +input_voltage + " out: " + output_voltage + " voltage: " + voltage);
    }

    public float getOutputVoltage(){
        return output_voltage;
    }

    // void Update(){
    //     voltage = current * resistence; //
    //     output_voltage = input_voltage - voltage;
    //     Debug.LogWarning("Update resistor... in: " +input_voltage + " out: " + output_voltage + " voltage: " + voltage);
    // }
    
}
