using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricalcomponent : MonoBehaviour
{
    public string component_type; //led, resistor, battery, interruptor
    public float input_voltage {set; get;} = 0.0f;
    public float output_voltage {set; get;} = 0.0f;
    public float voltage {set; get;} = 0.0f;
    public float current {set; get;} = 0.0f;
    public float resistence {set; get;} = 0.0f;


    public void setInputVoltage(float voltage){
        input_voltage = voltage;
    }

    public float getOutputVoltage(){
        return 0.0f;
    }
    
    public float getVoltage(float current){
        return current * resistence;
    }

    

    public float getCurrent(float voltage){
        return voltage / resistence;
    }
    
}
