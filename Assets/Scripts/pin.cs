using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simulates a component's pin.
*/
public class pin : MonoBehaviour
{

    public simulator simulator;
    public GameObject component;
    public string pin_id;
    
    // Indicate if is a battery's pin.
    public bool isSupply = false;
    public bool isGround = false;

    // Creates a node when it collides with another pin
    public void OnTriggerEnter(Collider pin){
        if(pin.gameObject.tag == "Pin"){
            simulator.setNode(this, pin.gameObject.GetComponent<pin>());
        }
    }
}
