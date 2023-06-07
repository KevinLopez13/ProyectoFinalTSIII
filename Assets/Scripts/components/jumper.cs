using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simulates the behavior of a jumper (cable).
*/
public class jumper : MonoBehaviour
{
    public float? input_voltage = 0.0f;
    public float? output_voltage = 0.0f;

    // The output voltage are the same as the input.
    public void setInputVoltage(float? volt){
        input_voltage = volt;
        output_voltage = input_voltage;
    }

    public float? getOutputVoltage(){
        return output_voltage;
    }
}
