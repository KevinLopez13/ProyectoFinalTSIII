using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class node : MonoBehaviour
{
    
    simulator simulator;
    public string node_id;
    public List<pin> pins;
    public bool isSupply {get; set; } = false;
    public bool isGround {get; set; } = false;
    public float Voltage = 0.0f;
    public float LenPins {
        get { return pins.Count;}
    }
    public node(string id, params pin[] args){
        node_id = id;
        pins = new List<pin>(args);
        isSupply = pins.Any(p => p.isSupply);
        isGround = pins.Any(p => p.isGround);
    }

    public void addPin(pin pin){
        pins.Add(pin);
    }

    public void removePin(pin pin){
        pins.Remove(pin);
    }

    public bool ContainsAllPins( params pin[] ps){
        bool all_in = Enumerable.All( ps, x => pins.Contains(x) );
        return all_in;
    }

    public bool ContainsAnyPins(params pin[] ps){
        bool any_in = Enumerable.Any( ps, x => pins.Contains(x) );
        return any_in;
    }

    public bool ContainsPin(pin pin){
        return pins.Contains(pin);
    }

    public bool BelongsToComponent(params GameObject[] comps){
        foreach(pin p in pins){
            if( comps.Contains( p.component )){
                return true;
            }
        }
        return false;
    }

    public GameObject getComponentByPin(pin pin){
        return pins.Find(p => p == pin).component;
    }

    public void swapPins(GameObject component){
        if( pins[0].component.name != component.name){
            pin tmp = pins[0];
            pins[0] = pins[1];
            pins[1] = tmp;
        }
    }

    override
    public string ToString(){
        IEnumerable<string> strings = pins.Select( p => p.pin_id.ToString());
        return node_id +" : "+ string.Join(',', strings);
    }


    // public void setVoltage(){
    //     foreach(pin p in pins){

    //         switch(p.componentType){
    //             case "battery":
    //                 battery batt = p.component.GetComponent<battery>();
    //                 break;
                
    //             case "resistor":
    //                 resistor res = p.component.GetComponent<resistor>();
    //                 break;

    //             case "interruptor":
    //                 interruptor swt = p.component.GetComponent<interruptor>();
    //                 break;

    //             case "led":
    //                 led led = p.component.GetComponent<led>();
    //                 break;
                    
    //             default:
    //                 break;
    //         }

    //         if(p.isSupply == true){
    //             Debug.LogWarning("Supply!! ");
    //             battery comp = (battery)p.component.GetComponent(p.componentType);
    //             Debug.LogWarning("Name: " + comp.voltage);
    //         }
    //     }
    // }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
