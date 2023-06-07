using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class manage the components by apply the same function at diferent classes.
*/
public class adapter : MonoBehaviour
{
    
    public battery battery;
    public resistor resistor;
    public led led;
    public interruptor interruptor;
    public jumper jumper;


    // Sets input voltage for its respective component.
    public void setInputVoltage(float? voltage, string pinid = null){
        if(battery != null)
            battery.setInputVoltage(voltage);

        if(resistor != null)
            resistor.setInputVoltage(voltage);

        if(led != null)
            led.setInputVoltage(voltage, pinid);

        if(interruptor != null)
            interruptor.setInputVoltage(voltage);

        if(jumper != null)
            jumper.setInputVoltage(voltage);
    }

    // Gets the output voltage for its respective component.
    public float? getOutputVoltage(){
        if(battery != null)
            return battery.getOutputVoltage();

        if(resistor != null)
            return resistor.getOutputVoltage();

        if(led != null)
            return led.getOutputVoltage();

        if(interruptor != null)
            return interruptor.getOutputVoltage();

        if(jumper != null)
            return jumper.getOutputVoltage();
        
        return 0.0f;
    }

    // Gets the load current for each component.
    public float getLoadCurrent(){
        // For now, led are the only load component.
        if(led != null)
            return led.current_load;
        
        return 0.0f;
    }

    // Sets the same circuits current to all components.
    public void setCircuitCurrent(float current){
        // Resistor needs current to cumpute his voltage consumption
        if(resistor != null)
            resistor.current = current;
    }

    // Triggered its respective fuction when is touched.
    public void onTouch(){
        if(interruptor != null)
            interruptor.onTouch();
    }
}
