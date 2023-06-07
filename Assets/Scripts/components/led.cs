using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simulates the behavior of a led.
*/
public class led : MonoBehaviour
{

    public GameObject led_on, led_off;
    public pin anode;

    public float? input_voltage = 0.0f;
    public float? output_voltage = 0.0f;
    public float voltage {get; set;} = 0.0f;
    public float voltage_lightup {get;} = 3.0f; // 3V of consumtion
    public float resistence {get;} = 0.0f;
    public float current {get; set;} = 0.0f;
    public float current_load {get;} = 0.006f;

    public void setInputVoltage(float? volt, string pinid){
        //Check polarity
        if(pinid == anode.pin_id)
            input_voltage = volt;
        else
            input_voltage = null;
        output_voltage = input_voltage == null ? null : input_voltage - voltage_lightup;
    }

    public float? getOutputVoltage(){
        return input_voltage == null ? null : output_voltage;
    }

    void Update()
    {
        if( input_voltage != null && (voltage_lightup - 0.3) <= input_voltage && input_voltage <= (voltage_lightup + 0.3) ){
            led_on.SetActive(true);
            led_off.SetActive(false);
        }
        else{
            led_on.SetActive(false);
            led_off.SetActive(true);
        }
    }
}
