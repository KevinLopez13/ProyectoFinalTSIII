using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interruptor : MonoBehaviour
{
    public bool state;

    public float input_voltage = 0.0f;
    public float output_voltage = 0.0f;

    public void OnMouseDown(){
        state = !state;
    }

    public void setInputVoltage(float volt){
        input_voltage = volt;

        if(state == true){
            output_voltage = input_voltage;
        }
        else{
            output_voltage = 0.0f;
        }

    }

    public float getOutputVoltage(){
        return output_voltage;
    }

    void Start()
    {
        state = false;
    }

}
