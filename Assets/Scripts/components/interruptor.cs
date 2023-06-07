using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simulates the behavior of a switch.
*/
public class interruptor : MonoBehaviour
{
    public bool state;
    public float? input_voltage = 0.0f;
    public float? output_voltage = 0.0f;

    // Update the state when is touched.
    public void onTouch(){
        state = !state;
    }

    public void setInputVoltage(float? volt){
        input_voltage = volt;
    }

    // Returns null when is off.
    public float? getOutputVoltage(){
        if(state == true){
            if(input_voltage == null)
                output_voltage = 0.0f;
            else
                output_voltage = input_voltage;
        }
        else{
            output_voltage = null;
        }

        return output_voltage;
    }

    void Start()
    {
        state = false;
    }

}
