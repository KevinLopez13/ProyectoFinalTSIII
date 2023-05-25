using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interruptor : MonoBehaviour
{
    public bool state;
    public float pin1, pin2;

    void OnMouseDown(){
        state = !state;
    }

    void Start()
    {
        state = false;
    }

    void Update()
    {
        if (state == true){
            pin2 = pin1;
        }
        else{
            pin2 = 0.0f;
        }
    }
}
