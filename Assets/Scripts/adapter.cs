using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adapter : MonoBehaviour
{
    
    public battery battery;
    public resistor resistor;
    public led led;
    public interruptor interruptor;

    public float getOutputVoltage(){
        // Returns the output voltage of each component
        if(battery != null)
            return battery.output_voltage;

        if(resistor != null)
            return resistor.getOutputVoltage();

        if(led != null)
            return led.getOutputVoltage();

        if(interruptor != null)
            return interruptor.getOutputVoltage();
        
        return 0.0f;
    }

    public void setInputVoltage(float voltage){
        // Battery dont needs input voltage (for the moment)

        if(resistor != null)
            resistor.setInputVoltage(voltage);

        if(led != null)
            led.setInputVoltage(voltage);

        if(interruptor != null)
            interruptor.setInputVoltage(voltage);
    }

    public float getLoadCurrent(){
        // Components consume current when they are loads
        
        // In this case, led are the only load component.
        if(led != null)
            return led.current_load;
        
        return 0.0f;
    }

    public void setCircuitCurrent(float current){
        // The current is the same for all components in series circuit
        if(resistor != null)
            resistor.current = current;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
