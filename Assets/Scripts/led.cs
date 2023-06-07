using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class led : MonoBehaviour
{

    // public float anode, cathode;  // +, -
    public GameObject led_on, led_off;

    public float input_voltage = 0.0f;
    public float output_voltage = 0.0f;
    public float voltage {get; set;} = 0.0f;
    public float voltage_lightup {get;} = 3.0f; // 3V
    public float resistence {get;} = 0.0f;
    public float current {get; set;} = 0.0f;
    public float current_load {get;} = 0.006f; //20mA

    public void setInputVoltage(float volt){
        input_voltage = volt;
        output_voltage = input_voltage - voltage_lightup;
    }

    public float getOutputVoltage(){
        return output_voltage;
    }

    void Update()
    {
        if( (voltage_lightup - 0.3) <= input_voltage && input_voltage <= (voltage_lightup + 0.3) ){
            led_on.SetActive(true);
            led_off.SetActive(false);
        }else{
            led_on.SetActive(false);
            led_off.SetActive(true);
        }
        
        // output_voltage = input_voltage - voltage_lightup;
    }
}
