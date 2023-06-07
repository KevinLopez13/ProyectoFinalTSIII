using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{

    public simulator simulator;
    public GameObject component;
    // public string componentType;
    // public List<string> componentType = new List<string>{"battery", "interruptor", "jumper", "led", "resistor"};
    public string pin_id;
    public bool isSupply = false;
    public bool isGround = false;

    public void OnTriggerEnter(Collider pin){
        if(pin.gameObject.tag == "Pin"){
            simulator.setNode(this, pin.gameObject.GetComponent<pin>());
            // Debug.LogWarning(pin_id + ">" + pin.gameObject.GetComponent<pin>().pin_id);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
