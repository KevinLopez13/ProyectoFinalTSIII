using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumper : MonoBehaviour
{
    public float pin1, pin2;
    void Start()
    {
        
    }

    public float getVoltage(){
        if (pin1 > pin2){
            pin2 = pin1;
            return pin2;
        }
        else
            pin1 = pin2;
            return pin1;
    }
}
